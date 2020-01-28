using Microdev.ASPNETCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microdev.ASPNETCore.Controllers
{
    public class HomeController: Controller
    {

        public IActionResult Index()
        {
            List<EmployeeViewModel> viewModel = new List<EmployeeViewModel>
            {
                new EmployeeViewModel{
                    EmployeeId = 100,
                    FirstName = "Zahra",
                    LastName = "Bayat",
                    DepartmentName = "Raveshmand",
                    Salary=10000000
                   },
                new EmployeeViewModel{
                    EmployeeId = 101,
                    FirstName = "Ali",
                    LastName = "Bayat",
                    DepartmentName = " Raveshmand ",
                    Salary=10000000

                },
            };

            return View(viewModel);


        }


        public string Error(int id)
        {
            return
            $"{id} Error: Oops! We couldn’t find the page you requested";
        }


    }
}
