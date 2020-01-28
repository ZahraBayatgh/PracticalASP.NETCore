using MediatR;

namespace Microdev.API.Application.Commands
{
    public class UpdateDepartmentCommand : IRequest<bool>
    {
        public UpdateDepartmentCommand()
        {

        }
        public UpdateDepartmentCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
