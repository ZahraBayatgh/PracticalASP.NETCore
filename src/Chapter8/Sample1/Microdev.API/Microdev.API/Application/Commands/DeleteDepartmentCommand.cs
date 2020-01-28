using MediatR;

namespace Microdev.API.Application.Commands
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public DeleteDepartmentCommand()
        {

        }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

}
