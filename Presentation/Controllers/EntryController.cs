using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Repositories;
using Services;
using Services.Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EntryController : ControllerBase
{
    private readonly ILogger<EntryController> _logger;
    private readonly IEntryService _entryService;

    public EntryController(ILogger<EntryController> logger, IEntryService entryService)
    {
        _logger = logger;
        _entryService = entryService;
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> getById(string id)
    {
        try
        {
            return Ok(await _entryService.GetEntryByIdAsync(id));
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
            return Ok(await _entryService.GetAllEntrysAsync());
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> post([FromBody] Entry entry){
        try
        {
            return Ok(await _entryService.AddEntryAsync(entry));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> put([FromBody] Entry entry,string id){
        try
        {
            return Ok(await _entryService.UpdateEntryAsync(entry,id));
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
            return Ok(await _entryService.DeleteEntryAsync(id));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}