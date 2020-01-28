using MediatR;

namespace Microdev.API.Application.Commands
{
    public class CreateDepartmentCommand : IRequest<bool>
    {
        public CreateDepartmentCommand()
        {

        }
        public CreateDepartmentCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

}
