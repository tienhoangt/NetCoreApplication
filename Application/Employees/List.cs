using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class List
    {
        public class Query : IRequest<Result<List<EmployeeInfo>>> { }

        public class Handler : IRequestHandler<Query, Result<List<EmployeeInfo>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }
            public async Task<Result<List<EmployeeInfo>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<EmployeeInfo>>.Success(await _context.Employees.ToListAsync());
            }
        }
    }
}
