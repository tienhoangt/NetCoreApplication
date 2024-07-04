using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await context.Employees.FindAsync(request.Id);
                context.Remove(employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
