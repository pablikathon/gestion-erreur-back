using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Repositories;
using Services;
using Services.Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpotterController : ControllerBase
{
    private readonly ILogger<SpotterController> _logger;
    private readonly ISpotterService _spotterService;

    public SpotterController(ILogger<SpotterController> logger, ISpotterService spotterService)
    {
        _logger = logger;
        _spotterService = spotterService;
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> getById(string id)
    {
        try
        {
            return Ok(await _spotterService.GetSpotterByIdAsync(id));
        }
        catch (System.Exception e)
        {
            EventId eventId= new EventId(1000);
            _logger.LogInformation(eventId,e.Message);
            return Problem(e.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> get()
    {
        try
        {
            return Ok(await _spotterService.GetAllSpottersAsync());
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> post([FromBody] Spotter spotter){
        try
        {
            return Ok(await _spotterService.AddSpotterAsync(spotter));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> put([FromBody] Spotter spotter,string id){
        try
        {
            return Ok(await _spotterService.UpdateSpotterAsync(spotter,id));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> delete(string id){
        try
        {
            return Ok(await _spotterService.DeleteSpotterAsync(id));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}