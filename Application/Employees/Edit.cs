using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Edit
    {
        public class Command : IRequest
        {
            public EmployeeInfo Employee { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await context.Employees.FindAsync(request.Employee.Id);
                mapper.Map(request.Employee, employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
