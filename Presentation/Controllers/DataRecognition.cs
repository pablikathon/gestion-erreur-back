using Microsoft.AspNetCore.Mvc;
using Persist.Entities;
using Repositories;
using Services;
using Services.Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataRecognitionController : ControllerBase
{
    private readonly ILogger<DataRecognitionController> _logger;
    private readonly IDataRecognition _dataRecognition;

    public DataRecognitionController(ILogger<DataRecognitionController> logger, IDataRecognition dataRecognition)
    {
        _logger = logger;
        _dataRecognition = dataRecognition;
    }
    [HttpGet]
    [Route("Search/{query}")]
    public async Task<IActionResult> Search(string query)
    {
        try
        {
            return Ok(await _dataRecognition.AanalyzText(query)); 
        }catch{
            return Problem();
        }
    }
     
}