using System.Text.Json;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Persist.Entities.JoiningTable;

using Presentation.Models.Req;

using Services;
using Services.Models.Command;
using Services.Models.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeployedApplicationController : Controller
{
    private readonly IApplicationDeployedOnServerService _applicationDeployedOnServerService;
    private readonly IMapper _mapper;

    public DeployedApplicationController(IApplicationDeployedOnServerService ApplicationDeployedOnServerService, IMapper mapper)
    {
        this._applicationDeployedOnServerService = ApplicationDeployedOnServerService;
        this._mapper = mapper;
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
    public async Task<ActionResult<ApplicationDeployedOnServerEntity>> DeployedApplicationOnServer(
        [FromBody] CreateApplicationDeployedRequest createApplicationDeployedRequest)
    {
        try
        {
            var createApplicationDeployedCommand = _mapper.Map<CreateApplicationDeployedCommand>(createApplicationDeployedRequest);
            return Created("/deployedServer",
                JsonSerializer.Serialize(
                    await _applicationDeployedOnServerService.DeployedApplicationOnServer(
                        createApplicationDeployedCommand)));
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
            var updateApplicationDeployedCommand = _mapper.Map<UpdateApplicationDeployedCommand>(updateApplicationDeployedRequest);
            var data =
                await _applicationDeployedOnServerService.UpdateDeployedApplicationDeployed(
                    updateApplicationDeployedCommand);
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
