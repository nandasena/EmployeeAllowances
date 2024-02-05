using EmployeeAllowances.API.Utility;
using EmployeeAllowances.Application;
using EmployeeAllowances.Application.Employee;
using EmployeeAllowances.Application.Utility;
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

        [HttpPost("ImportEmployeeAllowances", Name = "ImportEmployeeAllowances")]
        public async Task<BaseResponseDto> ImportEmployeeAllowances()
        {

            var result = await _mediator.Send(new EmployeeIntegrationCommand());
            return ResponceHandler.CreatedResult(new Meta() { IsSucceeded = result,HttpErrorCode= 200,Message = "File imported successfully." });
        }



        [HttpGet("GetEmployeeAllowances", Name = "GetEmployeeAllowances")]
        public async Task<ResponseDto<IEnumerable<EmployeeAllowanceDto>>> GetEmployeeAllowances()
        {
            var result = await _mediator.Send(new EmployeeAllowanceQuery());

            return ResponceHandler.ResponceCreator(result,
                new Meta() { IsSucceeded  = true,Message = "Success",HttpErrorCode = 200});
        }
    }
}
