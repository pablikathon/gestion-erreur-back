using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Services;
using Services.Models.Common;
using Services.Models.Req;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerLicenceController : Controller
{
    private readonly ICustomerHaveLicenceToService _customerHaveLicenceTo;

    public CustomerLicenceController(ICustomerHaveLicenceToService CustomerHaveLicenceToService)
    {
        this._customerHaveLicenceTo = CustomerHaveLicenceToService;
    }

    [HttpGet]
    public ActionResult<PaginationResponse<CustomerHaveLicenceToApplicationEntity>> GetApplicationsDeployed(
        [FromQuery] GenericQueryParameter queryParameters)
    {
        try
        {
            var data = _customerHaveLicenceTo.GetAll (queryParameters);
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
    [HttpPost]
    public async Task<ActionResult<ApplicationEntity>> Create(
    [FromBody] CreateCustomerHasLicenceToRequest createCustomerHasLicenceToRequest)
    {
        try
        {
            return Created("/deployedServer",
                JsonSerializer.Serialize(await _customerHaveLicenceTo.AddAsync(createCustomerHasLicenceToRequest)));
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> Update([FromBody] UpdateCustomerHasLicenceRequest updateApplicationDeployedRequest)
    {
        try
        {
            var data = await _customerHaveLicenceTo.UpdateAsync(updateApplicationDeployedRequest);
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
    public async Task<ActionResult<Boolean>> DeleteDeployedApplication([FromBody] DeleteCustomerHasLicenceRequest deleteCustomerHasLicenceRequest)
    {
        try
        {
            var data = await _customerHaveLicenceTo.DeleteAsync(deleteCustomerHasLicenceRequest.ApplicationId, deleteCustomerHasLicenceRequest.ServerId);
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

