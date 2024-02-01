using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Repositories;
using Services;
using Services.Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EntrySpotterController : ControllerBase
{
    private readonly ILogger<EntrySpotterController> _logger;
    private readonly IEntrySpotterService _entrySpotterService;

    public EntrySpotterController(ILogger<EntrySpotterController> logger, IEntrySpotterService entrySpotterService)
    {
        _logger = logger;
        _entrySpotterService = entrySpotterService;
    }

    [HttpGet]
    public async Task<IActionResult> get()
    {
        try
        {
            return Ok(await _entrySpotterService.GetAllEntrySpotterAsync());
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> post([FromBody] EntrySpotter entrySpotter){
        try
        {
            return Ok(await _entrySpotterService.AddEntrySpotterAsync(entrySpotter));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> delete(EntrySpotter entrySpotter){
        try
        {
            return Ok(await _entrySpotterService.DeleteEntrySpotterAsync(entrySpotter));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}