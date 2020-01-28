using Microdev.ASPNETCore.Models;
using Microdev.ASPNETCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Microdev.ASPNETCore.Controllers
{
    
    public class EmployeeController : Controller
    {
        public List<Employee> Employees { get; private set; }
        public EmployeeController()
        {
            Employees = new List<Employee>
            {
                new Employee{
                    EmployeeId = 100,
                    FirstName = "Zahra",
                    LastName = "Bayat",
                    Salary=1000000
                   },
                new Employee{
                    EmployeeId = 101,
                    FirstName = "Ali",
                    LastName = "Bayat",
                    Salary=1000000
                },
            };

        }
        public IActionResult GetEmployee(int employeeId)
        {
            var employee = Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            return Json(employee);
        }

        public IActionResult GetAllEmployee()
        {
            return Json(Employees);
        }

                public IActionResult CreateEmployee()
        {
            return View(new EmployeeViewModel());
        }

    }
}
