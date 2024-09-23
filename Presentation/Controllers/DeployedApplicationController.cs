using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities.BaseTable;
using Persist.Entities.JoiningTable;
using Services;
using Services.Models.Common;
using Services.Models.Req;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeployedApplicationController : Controller
{
    private readonly IApplicationDeployedOnServerService _applicationDeployedOnServerService;

    public DeployedApplicationController(IApplicationDeployedOnServerService ApplicationDeployedOnServerService)
    {
        this._applicationDeployedOnServerService = ApplicationDeployedOnServerService;
    }

    [HttpGet]
    public ActionResult<PaginationResponse<ApplicationDeployedOnServerEntity>> GetApplicationsDeployed(
        [FromQuery] GenericQueryParameter queryParameters)
    {
        try
        {
            var data = _applicationDeployedOnServerService.GetApplicationsDeployed(queryParameters);
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
    public async Task<ActionResult<ApplicationEntity>> DeployedApplicationOnServer(
        [FromBody] CreateApplicationDeployedRequest createApplicationDeployedRequest)
    {
        try
        {
            return Created("/deployedServer",
                JsonSerializer.Serialize(
                    await _applicationDeployedOnServerService.DeployedApplicationOnServer(
                        createApplicationDeployedRequest)));
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> UpdateApplication(
        [FromBody] UpdateApplicationDeployedRequest updateApplicationDeployedRequest)
    {
        try
        {
            var data =
                await _applicationDeployedOnServerService.UpdateDeployedApplicationDeployed(
                    updateApplicationDeployedRequest);
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
        [FromBody] DeleteApplicationDeployedRequest deleteApplicationDeployedRequest)
    {
        try
        {
            var data = await _applicationDeployedOnServerService.DeleteDeployedApplication(
                deleteApplicationDeployedRequest.ApplicationId, deleteApplicationDeployedRequest.ServerId);
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