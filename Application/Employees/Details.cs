using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Details
    {
        public class Query : IRequest<Result<EmployeeInfo>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<EmployeeInfo>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                this._dataContext = dataContext;
            }
            public async Task<Result<EmployeeInfo>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _dataContext.Employees.FindAsync(request.Id);

                return Result<EmployeeInfo>.Success(employee);
            }
        }
    }
}
