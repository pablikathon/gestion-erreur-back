using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Services;
using Services.Models.Common;
using Services.Models.Req;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : Controller
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }

    [HttpGet]
    public async Task<ActionResult<PaginationResponse<ApplicationEntity>>> GetApplication(
        [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data = _applicationService.GetApplications(queryParameters);
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
    public async Task<ActionResult<ApplicationEntity>> CreateApplication(
        [FromBody] CreateApplicationRequest applicationRequest)
    {
        try
        {
            return Created("/Application",
                JsonSerializer.Serialize(await _applicationService.CreateApplication(applicationRequest)));
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> UpdateApplication([FromBody] UpdateApplicationRequest applicationRequest)
    {
        try
        {
            var data = await _applicationService.UpdateApplication(applicationRequest);
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
    public async Task<ActionResult<Boolean>> DeleteApplication(string id)
    {
        try
        {
            var data = await _applicationService.DeleteApplication(id);
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