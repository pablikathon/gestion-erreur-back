using System.Text.Json;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Persist.Entities.BaseTable;

using Presentation.Models.Req;

using Services;
using Services.Models.Command;
using Services.Models.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<PaginationResponse<CustomerEntity>> GetCustomers(
        [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data = _customerService.GetCustomers(queryParameters);
            if (data.TotalItems > 0)
            {
                return Ok(JsonSerializer.Serialize(data));
            }

            return NoContent();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet("stats")]
    public ActionResult<PaginationResponse<ErrorForCustommerStatsResponse>> GetCustomersErrorStats(
        [FromQuery] QueryParameters queryParameters
    )
    {
        try
        {
            var data = _customerService.GetErrorsForClientStats(queryParameters);

            return Ok(JsonSerializer.Serialize(data));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CustomerEntity>> CreateCustomer([FromBody] CreateCustomerRequest customerRequest)
    {
        try
        {
            var createCustomerCommand = _mapper.Map<CreateCustomerCommand>(customerRequest);
            return Created("/Customer",
                JsonSerializer.Serialize(await _customerService.CreateCustomer(createCustomerCommand)));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> UpdateCustomer([FromBody] UpdateCustomerRequest customerRequest)
    {
        try
        {
            var updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customerRequest);
            var data = await _customerService.UpdateCustomer(updateCustomerCommand);
            if (data)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpDelete("id")]
    public async Task<ActionResult<Boolean>> DeleteCustomer(string id)
    {
        try
        {
            var data = await _customerService.DeleteCustomer(id);
            if (data)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}
