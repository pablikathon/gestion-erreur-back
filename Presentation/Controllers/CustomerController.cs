using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Services;
using Services.Models.Common;
using Services.Models.Req;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService){
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<PaginationResponse<CustomerEntity>>> GetCustomers([FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data =  _customerService.GetCustomers(queryParameters);
            if (data.TotalItems > 0){
                return Ok(JsonSerializer.Serialize(data));
            }
            return NoContent();
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
            return Created("/Customer",JsonSerializer.Serialize(await _customerService.CreateCustomer(customerRequest)));
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
            var data = await _customerService.UpdateCustomer(customerRequest);
            if (data){
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
            var data = await _customerService.DeleteApplication(id);
            if (data){
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