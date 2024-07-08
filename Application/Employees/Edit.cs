using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EmployeeInfo Employee { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Employee).SetValidator(new EmployeeValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await context.Employees.FindAsync(request.Employee.Id);
                if (employee == null) return null;
                mapper.Map(request.Employee, employee);
                var rs = await context.SaveChangesAsync() > 0;
                return rs ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to edit employee");
            }
        }
    }
}
