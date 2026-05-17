using System.Text.Json;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Persist.Entities.Application;

using Presentation.Models.Req;

using Services;
using Services.Models.Command;
using Services.Models.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ApplicationController : Controller
{
    private readonly IApplicationService _applicationService;
    private readonly IMapper _mapper;

    public ApplicationController(IApplicationService applicationService, IMapper mapper)
    {
        this._applicationService = applicationService;
        this._mapper = mapper;
    }

    [HttpGet]
    public ActionResult<PaginationResponse<ApplicationEntity>> GetApplication(
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
            var application = _mapper.Map<CreateApplicationCommand>(applicationRequest);
            return Created("/Application",
                JsonSerializer.Serialize(await _applicationService.CreateApplication(application)));
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
            var updateApplicationCommand = _mapper.Map<UpdateApplicationCommand>(applicationRequest);

            var data = await _applicationService.UpdateApplication(updateApplicationCommand);
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
