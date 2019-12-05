using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Employees
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string EmpCode { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public DateTime? DateCreated { get; set; }
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
                var employee = await _context.Empoloyees.FindAsync(request.Id);

                if (employee == null)
                    throw new Exception("Could not find employee");

                employee.LastName = request.LastName ?? employee.LastName;
                employee.FirstName = request.FirstName ?? employee.FirstName;
                employee.MiddleName = request.MiddleName ?? employee.MiddleName;
                employee.DateCreated = request.DateCreated ?? employee.DateCreated;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}