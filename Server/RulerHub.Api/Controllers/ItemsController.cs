using Microsoft.AspNetCore.Mvc;
using RulerHub.Services.Helpers;
using RulerHub.Services.Interface;
using RulerHub.Shared.DataTransferObjects.Item;
using RulerHub.Shared.Mappers;

namespace RulerHub.Api.Controllers;

[Route("api/items")]
[ApiController]
public class ItemsController(IItemService service) : ControllerBase
{
    private readonly IItemService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryItem query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var items = await _service.GetItemAsync(query);
        var itemsDto = items.Select(i => i.ToItemDto());
        return Ok(itemsDto);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var item = await _service.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.ToItemDto());
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateItemDto item)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var model = item.ToItemFromCreateDto();
        await _service.CreateAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToItemDto());
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromBody] UpdateItemDto update, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var model = await _service.UpdateAsync(id, update);
        if (model is null)
        {
            return NotFound();
        }

        return Ok(model.ToItemDto());
    }
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var model = _service.DeleteAsync(id);
        if (model is null)
        {
            return NotFound();
        }
        return NoContent();
    }
}
