using MediatR;
using Microdev.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microdev.API.Application.Commands
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly MicrodevAppDbContext _context;

        public UpdateDepartmentCommandHandler(MicrodevAppDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _context.Departments.Find(request.Id);
            department.UpdateName(request.Name);

            await _context.SaveChangesAsync();

            return true;
        }
    }

}
