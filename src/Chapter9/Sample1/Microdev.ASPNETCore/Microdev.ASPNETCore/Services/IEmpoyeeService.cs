using System.Collections.Generic;
using Microdev.ASPNETCore.ViewModels;
namespace Microdev.ASPNETCore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeViewModel GetEmployee(int employeeId);
        EmployeeViewModel CreateEmployee();
    }
}
