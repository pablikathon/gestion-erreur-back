using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Services;
using Services.Models.Common;
using Services.Models.Req;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerController : Controller
{
    private readonly IServerService _serverService;

    public ServerController(IServerService serverService)
    {
        _serverService = serverService;
    }

    [HttpGet]
    public ActionResult<PaginationResponse<ServerEntity>> GetServers(
        [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data = _serverService.GetServers(queryParameters);
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
    public async Task<ActionResult<ServerEntity>> CreateServer([FromBody] CreateServerRequest createServerRequest)
    {
        try
        {
            return Created("/application",
                JsonSerializer.Serialize(await _serverService.CreateServer(createServerRequest)));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> UpdateCustomer([FromBody] UpdateServerRequest updateServerRequest)
    {
        try
        {
            var data = await _serverService.UpdateServer(updateServerRequest);
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
    public async Task<ActionResult<Boolean>> DeleteCustomer(string id)
    {
        try
        {
            var data = await _serverService.DeleteServer(id);
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