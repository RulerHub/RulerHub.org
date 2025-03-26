using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulerHub.Data.Services.Logistic.Providers.Interface;
using RulerHub.Shared.DataTransferObjects.Generic;
using RulerHub.Shared.DataTransferObjects.Logistic.Providers;

namespace wKeeper.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProviderController(IProviderService service) : ControllerBase
{
    private readonly IProviderService _service = service;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = new ResponseDto<List<ProviderDto>>();
        try
        {
            response.Value = await _service.GetAsync();
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = new ResponseDto<ProviderDto>();
        try
        {
            response.Value = await _service.GetByIdAsync(id);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProviderDto model)
    {
        var response = new ResponseDto<ProviderDto>();
        try
        {
            response.Value = await _service.CreateAsync(model);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }
        return Ok(response);
    }

    [HttpPost]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody]ProviderDto model)
    {
        var response = new ResponseDto<ProviderDto>();
        try
        {
            response.Value = await _service.UpdateAsync(id, model);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }
        return Ok(response);
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = new ResponseDto<ProviderDto>();
        try
        {
            response.Value = await _service.DeleteAsync(id);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }
        return Ok(response);
    }
}
