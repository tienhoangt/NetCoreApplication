using Domain;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Create
    {
        public class Command : IRequest
        {
            public EmployeeInfo EmployeeInfo { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Employees.Add(request.EmployeeInfo);

                await _context.SaveChangesAsync();
            }
        }
    }
}
