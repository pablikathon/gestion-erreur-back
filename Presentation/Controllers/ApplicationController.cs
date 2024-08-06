using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Services;
using Services.Models.Common;
using Services.Models;
using Services.Models.Req;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : Controller{
    private readonly IApplicationService _applicationService;
    public ApplicationController(IApplicationService applicationService){
        this._applicationService = applicationService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationEntity>>> GetApplication([FromQuery] QueryParameters queryParameters)
    {
        try
        {
            return Ok(JsonSerializer.Serialize(await _applicationService.GetApplications(queryParameters)));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);       
        }
    }
    [HttpPost]
    public async Task<ActionResult<IEnumerable<ApplicationEntity>>> CreateApplication([FromBody] ApplicationRequest applicationRequest)
    {
        try
        {            
            return Created("/Application",JsonSerializer.Serialize(await _applicationService.CreateApplication(applicationRequest)));
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return Problem(e.Message);       
        }
    }
}