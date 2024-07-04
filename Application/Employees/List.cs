using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class List
    {
        public class Query : IRequest<List<EmployeeInfo>> { }

        public class Handler : IRequestHandler<Query, List<EmployeeInfo>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }
            public async Task<List<EmployeeInfo>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Employees.ToListAsync();
            }
        }
    }
}
