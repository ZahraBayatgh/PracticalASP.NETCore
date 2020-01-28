namespace Microdev.ASPNETCore.Controllers
{
    public class HomeController
    {
        public string Error(int id)
        {
            return
            $"{id} Error: Oops! We couldn’t find the page you requested";
        }


    }
}
