using EMS.Application.PipeLines.Departments.Queries.GetDepartmentMasterData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("getDepartmentMasterData")]
        public async Task<IActionResult> GetDepartmentMasterData()
        {
            var response = await _mediator.Send(new GetDepartmentMasterDataQuery());
            return Ok(response);
        }
    }
}
