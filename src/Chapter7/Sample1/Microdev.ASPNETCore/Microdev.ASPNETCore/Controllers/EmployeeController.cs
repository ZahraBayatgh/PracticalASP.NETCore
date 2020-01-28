using Microdev.ASPNETCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microdev.ASPNETCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        public IActionResult CreateEmployee()
        {
            var model = _service.CreateEmployee();
            return View(model);
        }

        public IActionResult GetEmployee(int employeeId)
        {
            var model = _service.GetEmployee(employeeId);
            return View(model);
        }

        public IActionResult GetAllEmployee()
        {
            var model = _service.GetAllEmployee();
            return View(model);
        }

    }
}
