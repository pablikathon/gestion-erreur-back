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
public class ErrorController : Controller
{
    private readonly IErrorService _errorService;
    private readonly IMapper _mapper;

    public ErrorController(IErrorService errorService, IMapper mapper)
    {
        this._errorService = errorService;
        this._mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateError(CreateErrorRequest createErrorRequest)
    {
        try
        {
            var createErrorCommand = _mapper.Map<CreateErrorCommand>(createErrorRequest);
            var data = await _errorService.AddAsync(createErrorCommand);
            if (data)
            {
                return Ok();
            }

            return Problem("Erreur non inséré");
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpDelete("id")]
    public async Task<ActionResult> DeleteError(string id)
    {
        try
        {
            if (await _errorService.DeleteAsync(id))
            {
                return Ok();
            }

            return Problem();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut]
    public ActionResult UpdateError(UpdateErroRequest updateErroRequest)
    {
        try
        {
            var updateErrorCommand = _mapper.Map<UpdateErroCommand>(updateErroRequest);
            return Ok(_errorService.UpdateErrors(updateErrorCommand));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpGet("Customer/{CustomerId}")]
    public ActionResult<PaginationResponse<Services.Models.Command.ErrorForACustommerStatsResponse>> GetErrorForACustommerAgregate(string CustomerId,
    [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data = _errorService.GetErrorsForACustommerAgregate(queryParameters, CustomerId);
            if (data.TotalItems > 0)
            {
                return Ok(data);
            }

            return NoContent();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpGet("Customer")]
    public ActionResult<PaginationResponse<ErrorEntity>> GetErrorForACustommer([FromQuery] GetErrorRequest GetErrorRequest,
    [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var getErrorCommand = _mapper.Map<GetErrorCommand>(GetErrorRequest);
            var data = _errorService.GetErrorsForACustommer(queryParameters, getErrorCommand);
            if (data.TotalItems > 0)
            {
                return Ok(data);
            }

            return NoContent();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}
