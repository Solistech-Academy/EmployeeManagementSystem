using EMS.Application.DTOs.CommonDTOs;
using EMS.Application.DTOs.EmployeeDTOs;
using EMS.Application.PipeLines.Employees.Commands.DeactivateEmplyee;
using EMS.Application.PipeLines.Employees.Commands.SaveEmployee;
using EMS.Application.PipeLines.Employees.Queries.GetEmployeeById;
using EMS.Application.PipeLines.Employees.Queries.GetEmployeesByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("saveEmployee")]
        public async Task<IActionResult> SaveEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var response = await _mediator.Send(new SaveEmployeeCommand(employeeDTO));
            return Ok(response);
        }

        [HttpGet("getEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var response = await _mediator.Send(new GetEmployeeByIdCommand(id));
            return Ok(response);
        }

        [HttpDelete("deactivateEmployee/{id}")]
        public async Task<IActionResult> DeactivateEmployeeById(int id)
        {
            var response = await _mediator.Send(new DeactivateEmployeeByIdCommand(id));
            return Ok(response);
        }

        [HttpGet("filterEmployees")]
        public async Task<IActionResult> GetEmployeeByFilter([FromQuery] EmployeeFilterDTO employeeFilterDTO)
        {
            var response = await _mediator.Send(new GetEmployeesByFilterQuery(employeeFilterDTO));
            return Ok(response);
        }


    }
}
