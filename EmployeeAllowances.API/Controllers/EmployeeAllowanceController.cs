using EmployeeAllowances.Application.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAlowances.EmployeeAllowances.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAllowanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeAllowanceController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpGet("ImportEmployeeAllowances", Name = "ImportEmployeeAllowances")]
        public async Task<IActionResult> ImportEmployeeAllowances()
        {

            await _mediator.Send(new EmployeeIntegrationCommand());
            return Ok(new { statues="File import successfully." });
        }
    }
}
