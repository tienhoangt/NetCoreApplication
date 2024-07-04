using Application.Employees;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeInfoController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<EmployeeInfo>>> GetEmployees()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInfo>> GetEmployee(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeInfo employee)
        {
            await Mediator.Send(new Create.Command { EmployeeInfo = employee });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(Guid id, EmployeeInfo employee)
        {
            employee.Id = id;
            await Mediator.Send(new Edit.Command { Employee = employee });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}
