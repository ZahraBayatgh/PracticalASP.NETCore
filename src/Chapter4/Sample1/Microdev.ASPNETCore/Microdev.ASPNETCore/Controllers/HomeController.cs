using Microsoft.AspNetCore.Mvc;

namespace Microdev.ASPNETCore.Controllers
{
    public class HomeController: Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public string Error(int id)
        {
            return
            $"{id} Error: Oops! We couldn’t find the page you requested";
        }


    }
}
