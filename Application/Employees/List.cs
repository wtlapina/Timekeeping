using MediatR;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees
{
    public class List
    {
        public class Query : IRequest<List<Employee>> { }

        public class Handler : IRequestHandler<Query, List<Employee>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Employee>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = await _context.Empoloyees.ToListAsync();

                return employees;
            }
        }
    }
}