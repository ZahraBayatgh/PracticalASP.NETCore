using System.Collections.Generic;
using System.Linq;
using Microdev.ASPNETCore.ViewModels;
namespace Microdev.ASPNETCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<EmployeeViewModel> Employees { get; }
        public EmployeeService()
        {
            Employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel{
                    EmployeeId = 100,
                    FirstName = "Zahra",
                    LastName = "Bayat",
                    DepartmentName = "Raveshmand",
                    Salary=1000000
                   },
                new EmployeeViewModel{
                    EmployeeId = 101,
                    FirstName = "Ali",
                    LastName = "Bayat",
                    DepartmentName = " Raveshmand",
                    Salary=1000000
                },
            };
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            return Employees;
        }
        public EmployeeViewModel GetEmployee(int employeeId)
        {
            return Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public EmployeeViewModel CreateEmployee()
        {
            return new EmployeeViewModel();
        }
    }
}
