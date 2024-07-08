using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EmployeeInfo EmployeeInfo { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmployeeInfo).SetValidator(new EmployeeValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Employees.Add(request.EmployeeInfo);

                var rsAdd = await _context.SaveChangesAsync() > 0;
                return rsAdd ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create employee");
            }
        }
    }
}
