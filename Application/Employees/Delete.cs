using Application.Core;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await context.Employees.FindAsync(request.Id);
                if (employee == null) return null;
                context.Remove(employee);
                var rs = await context.SaveChangesAsync() > 0;

                return rs ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete employee");
            }
        }
    }
}
