using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string EmpCode { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public DateTime DateCreated { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = new Employee
                {
                    Id = request.Id,
                    EmpCode = request.EmpCode,
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    DateCreated = request.DateCreated
                };

                _context.Empoloyees.Add(employee);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}