using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eStore.Api.Data;
using eStore.Api.Entities;
using eStore.Api.Services.Interface;
using eStore.Api.Mappers;
using eStore.Api.DataTransferObjets.CategoryDtos;

namespace eStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService service) : ControllerBase
{
    private readonly ICategoryService _service = service;

    // GET: api/Categories
    [HttpGet]
    [Route("GetAll")]
    [EndpointSummary("Get All")]
    public async Task<IActionResult> GetAllAsync()
    {
        var model = await _service.GetAsync();
        var modelDto = model.Select(i => i.ToCategoryDto());
        return Ok(modelDto);
    }

    // GET: api/Categories/5
    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var model = await _service.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model.ToCategoryDto());
    }

    // PUT: api/Categories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    [Route("Update/{id:int}")]
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

    // POST: api/Categories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Route("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var model = dto.ToCategoryFromCreateDto();
        await _service.CreateAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToCategoryDto());
    }

    // DELETE: api/Categories/5
    [HttpDelete]
    [Route("Delete/{id:int}")]
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
