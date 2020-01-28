using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microdev.ASPNETCore.ViewModels;

namespace Microdev.ASPNETCore.Services
{

    public class TestEmployeeService : IEmployeeService
    {
        public IEnumerable<EmployeeViewModel> Employees { get; }
        public TestEmployeeService()
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
                    DepartmentName = "Raveshmand",
                    Salary=3000000
                },
                 new EmployeeViewModel{
                    EmployeeId = 102,
                    FirstName = "Sara",
                    LastName = "Sadeghi",
                    DepartmentName = "Raveshmand",
                    Salary=2500000
                   },
                new EmployeeViewModel{
                    EmployeeId = 103,
                    FirstName = "Amin",
                    LastName = "Eshaghi",
                    DepartmentName = "Raveshmand",
                    Salary=5000000
                },
            };
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            return Employees.Where(x => x.Salary > 2500000).ToList();
        }

        public EmployeeViewModel GetEmployee(int employeeId)
        {
            return Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public EmployeeViewModel CreateEmployee()
        {
            return new EmployeeViewModel { DepartmentName = "Raveshmand" };
        }
    }
}
