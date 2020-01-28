using MediatR;
using Microdev.Infrastructure.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Microdev.API.Application.Commands
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly MicrodevAppDbContext _context;

        public DeleteDepartmentCommandHandler(MicrodevAppDbContext microdevAppDbContext)
        {
            _context = microdevAppDbContext;
        }
        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            bool isDeleted = false;
            var department = _context.Departments.Find(request.Id);

            if (department != null)
            {
                _context.Remove(department);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }

            return isDeleted;
        }
    }
}

