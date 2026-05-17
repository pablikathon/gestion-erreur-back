using System.Text.Json;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Persist.Entities.BaseTable;

using Presentation.Models.Req;

using Services;
using Services.Models.Command;
using Services.Models.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServerController : Controller
{
    private readonly IServerService _serverService;
    private readonly IMapper _mapper;

    public ServerController(IServerService serverService, IMapper mapper)
    {
        _serverService = serverService;
        _mapper = mapper;
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
            var createServerCommand = _mapper.Map<CreateServerCommand>(createServerRequest);
            return Created("/application",
                JsonSerializer.Serialize(await _serverService.CreateServer(createServerCommand)));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Boolean>> UpdateServer([FromBody] UpdateServerRequest updateServerRequest)
    {
        try
        {
            var updateServerCommand = _mapper.Map<UpdateServerCommand>(updateServerRequest);
            var data = await _serverService.UpdateServer(updateServerCommand);
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
    public async Task<ActionResult<Boolean>> DeleteServer(string id)
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
