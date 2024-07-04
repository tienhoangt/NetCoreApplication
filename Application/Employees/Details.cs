using Domain;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Details
    {
        public class Query : IRequest<EmployeeInfo>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, EmployeeInfo>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                this._dataContext = dataContext;
            }
            public async Task<EmployeeInfo> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Employees.FindAsync(request.Id);
            }
        }
    }
}
