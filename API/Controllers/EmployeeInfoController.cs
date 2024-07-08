using Application.Employees;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeInfoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeInfo employee)
        {
            return HandleResult(await Mediator.Send(new Create.Command { EmployeeInfo = employee }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(Guid id, EmployeeInfo employee)
        {
            employee.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Employee = employee }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
