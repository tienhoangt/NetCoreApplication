using Domain;
using FluentValidation;

namespace Application.Employees
{
    public class EmployeeValidator : AbstractValidator<EmployeeInfo>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty();
            RuleFor(x => x.EmployeeId).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
        }
    }
}
