using System;
using Microsoft.AspNetCore.Mvc;
using Microdev.ASPNETCore.Models;
using Microdev.ASPNETCore.Services;

namespace Microdev.ASPNETCore.Controllers
{
    public class EmployeeController : Controller
    {
        readonly Func<EnviromentServiceType, IEmployeeService> _service;

        public EmployeeController(Func<EnviromentServiceType, IEmployeeService> enviromentServiceType)
        {
            _service = enviromentServiceType;
        }

        public IActionResult CreateEmployee()
        {
            var service = _service(EnviromentServiceType.TestEmployeeService);
            var model = service.CreateEmployee();
            return View(model);
        }
        public IActionResult GetEmployee(int employeeId)
        {
            var service = _service(EnviromentServiceType.TestEmployeeService);
            var model = service.GetEmployee(employeeId);
            return View(model);
        }

        public IActionResult GetAllEmployee()
        {
            var service = _service(EnviromentServiceType.TestEmployeeService);
            var model = service.GetAllEmployee();
            return View(model);


        }

    }
}
