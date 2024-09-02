using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Repositories;
using Services;
using Services.Models.Common;
using Services.Models.Req;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorController : Controller
{
    private readonly IErrorService _errorService;

    public ErrorController(IErrorService errorService)
    {
        this._errorService = errorService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateError(CreateErrorRequest createErrorRequest)
    {
        try
        {
            var data = await _errorService.AddAsync(createErrorRequest);
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
            return Ok(_errorService.UpdateErrors(updateErroRequest));
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}