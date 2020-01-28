using MediatR;
using Microdev.Domain.Entities;
using Microdev.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Microdev.API.Application.Commands
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly MicrodevAppDbContext _context;

        public CreateDepartmentCommandHandler(MicrodevAppDbContext microdevAppDbContext)
        {
            _context = microdevAppDbContext;
        }
        public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department(request.Name);

            await _context.AddAsync(department);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
