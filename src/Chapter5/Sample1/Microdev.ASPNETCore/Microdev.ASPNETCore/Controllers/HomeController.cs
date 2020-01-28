using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microdev.ASPNETCore.Controllers
{
    public class HomeController: Controller
    {

        public IActionResult Index()
        {
            var employeeNames = new List<string> { "Zahra", " Ali", " Sara" };

            return View(employeeNames);

        }


        public string Error(int id)
        {
            return
            $"{id} Error: Oops! We couldn’t find the page you requested";
        }


    }
}
