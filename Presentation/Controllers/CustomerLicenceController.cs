using System.Text.Json;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Persist.Entities;

using Presentation.Models.Req;

using Services;
using Services.Models.Command;
using Services.Models.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerLicenceController : Controller
{
    private readonly ICustomerHaveLicenceToService _customerHaveLicenceTo;
    private readonly IMapper _mapper;

    public CustomerLicenceController(ICustomerHaveLicenceToService CustomerHaveLicenceToService, IMapper mapper)
    {
        this._customerHaveLicenceTo = CustomerHaveLicenceToService;
        this._mapper = mapper;
    }

    [HttpGet]
    public ActionResult<PaginationResponse<CustomerHaveLicenceToApplicationEntity>> GetApplicationsDeployed(
        [FromQuery] GenericQueryParameter queryParameters)
    {
        try
        {
            var data = _customerHaveLicenceTo.GetAll(queryParameters);
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
    public async Task<ActionResult<CustomerHaveLicenceToApplicationEntity>> Create(
        [FromBody] CreateCustomerHasLicenceToRequest createCustomerHasLicenceToRequest)
    {
        try
        {
            var createCustomerHaveLicenceToCommand = _mapper.Map<CreateCustomerHasLicenceToCommand>(createCustomerHasLicenceToRequest);
            return Created("/deployedServer",
                JsonSerializer.Serialize(await _customerHaveLicenceTo.AddAsync(createCustomerHaveLicenceToCommand)));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> Update(
        [FromBody] UpdateCustomerHasLicenceRequest updateApplicationDeployedRequest)
    {
        try
        {
            var updateCustomerHaveLicenceToCommand = _mapper.Map<UpdateCustomerHasLicenceCommand>(updateApplicationDeployedRequest);
            var data = await _customerHaveLicenceTo.UpdateAsync(updateCustomerHaveLicenceToCommand);
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
    public async Task<ActionResult<Boolean>> DeleteDeployedApplication(
        [FromBody] DeleteCustomerHasLicenceRequest deleteCustomerHasLicenceRequest)
    {
        try
        {
            var data = await _customerHaveLicenceTo.DeleteAsync(deleteCustomerHasLicenceRequest.ApplicationId,
                deleteCustomerHasLicenceRequest.ServerId);
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
