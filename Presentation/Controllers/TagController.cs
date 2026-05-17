using Microsoft.AspNetCore.Mvc;

using Persist.Entities.Catalyst;

using Presentation.Models.Req;

using Services;
using Services.Models.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    [HttpGet()]
    public ActionResult<PaginationResponse<TagEntity>> GetAllTags(
        [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data = _tagService.GetTags(queryParameters);
            if (data.TotalItems > 0)
            {
                return Ok((data));
            }

            return NoContent();
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    [HttpPost]
    public async Task<ActionResult<TagEntity>> CreateTag(
    [FromBody] CreateTagRequest CreateTagRequest)
    {
        try
        {
            return Created("/CreateTag",
                await _tagService.CreateTag(CreateTagRequest));
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return Problem(e.Message);
        }
    }
    [HttpPut("id")]
    public async Task<ActionResult<Boolean>> UpdateTag([FromBody] UpdateTagRequest updateTagRequest, string id)
    {
        try
        {
            var data = await _tagService.UpdateTag(updateTagRequest, id);
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
    public async Task<ActionResult<Boolean>> DeleteTag(string id)
    {
        try
        {
            var data = await _tagService.DeleteTag(id);
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
    [HttpGet("categories")]
    public ActionResult<PaginationResponse<TagCategoryEntity>> GetTagsCategories(
        [FromQuery] QueryParameters queryParameters)
    {
        try
        {
            var data = _tagService.GetCategories(queryParameters);
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
    [HttpPost("categories")]
    public async Task<ActionResult<TagEntity>> CreateTagCategories(
    [FromBody] CreateTagCategoryRequest CreateTagRequest)
    {
        try
        {
            return Created("/CreateTagCategories",
                await _tagService.CreateTagCategory(CreateTagRequest));
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return Problem(e.Message);
        }
    }
    [HttpPut("categories/{id}")]
    public async Task<ActionResult<Boolean>> UpdateTagCategories([FromBody] UpdateTagCategoryRequest updateTagRequest, string id)
    {
        try
        {
            var data = await _tagService.UpdateTagCategory(updateTagRequest, id);
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
    [HttpDelete("categories/{id}")]
    public async Task<ActionResult<Boolean>> DeleteTagCategories(string id)
    {
        try
        {
            var data = await _tagService.DeleteTagCategories(id);
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
