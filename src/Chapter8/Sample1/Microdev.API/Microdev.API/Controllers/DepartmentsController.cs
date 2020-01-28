using Microdev.API.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microdev.API.Application.Queries;

namespace Microdev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentQueries _departmentQueries;

        public DepartmentsController(IMediator mediator, ILogger<DepartmentsController> logger, IDepartmentQueries departmentQueries)
        {
            _mediator = mediator;
            _logger = logger;
            _departmentQueries = departmentQueries;
        }

        [HttpGet("departments-salary")]
        public async Task<ActionResult<IEnumerable<DepartmentWithSalaryDTO>>> GetAllDepartmentsWithSalaryAsync()
        {
            var departments = await _departmentQueries.GetAllDepartmentsWithSalaryAsync();

            return Ok(departments);
        }

        [HttpGet("expensive-employees")]
        public async Task<ActionResult<IEnumerable<string>>> GetExpensiveEmployeesAsync()
        {
            var employees = await _departmentQueries.GetExpensiveEmployeesAsync();

            return Ok(employees);
        }
        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<bool>> CreateDepartmentAsync([FromBody]CreateDepartmentCommand createDepartmentCommand)
        {
            bool commandResult = false;

            _logger.LogInformation(
        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                createDepartmentCommand.GetType().Name,
                nameof(createDepartmentCommand.Name),
                createDepartmentCommand.Name,
                createDepartmentCommand);

            commandResult = await _mediator.Send(createDepartmentCommand);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Departments
        [HttpPut]
        public async Task<ActionResult> UpdateDepartmentAsync(UpdateDepartmentCommand updateDepartmentCommand)
        {
            bool commandResult = false;

            _logger.LogInformation(
        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                updateDepartmentCommand.GetType().Name,
                nameof(updateDepartmentCommand.Id),
                updateDepartmentCommand.Id,
                updateDepartmentCommand);

            commandResult = await _mediator.Send(updateDepartmentCommand);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Departments/id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDepartmentAsync(int id)
        {
            bool commandResult = false;

            var deleteDepartmentCommand = new DeleteDepartmentCommand(id);

            _logger.LogInformation(
        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                deleteDepartmentCommand.GetType().Name,
                nameof(deleteDepartmentCommand.Id),
                deleteDepartmentCommand.Id,
                deleteDepartmentCommand);

            commandResult = await _mediator.Send(deleteDepartmentCommand);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

    }



}
