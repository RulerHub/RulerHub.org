using RulerHub.Shared.Mappers;
using Microsoft.AspNetCore.Mvc;
using RulerHub.Services.Interface;
using RulerHub.Shared.DataTransferObjects.Category;

namespace RulerHub.Api.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController(ICategoryService service) : ControllerBase
{
    private readonly ICategoryService _service = service;

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _service.GetCategoryAsync();
        var categoryDto = categories.Select(i => i.ToCategoryDto());
        return Ok(categoryDto);
    }
    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var category = await _service.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category.ToCategoryDto());
    }
    [HttpPost]
    [Route("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDto category)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var model = category.ToCategoryFromCreateDto();
        await _service.CreateAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToCategoryDto());
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryDto update, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var model = await _service.UpdateAsync(id, update);
        if (model is null)
        {
            return NotFound();
        }
        return Ok(model.ToCategoryDto());
    }
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var model = _service.DeleteAsync(id);
        if (model is null)
        {
            return NotFound();
        }
        return NoContent();
    }
}
