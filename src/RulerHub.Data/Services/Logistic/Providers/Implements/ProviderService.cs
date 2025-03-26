using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using RulerHub.Data.Mappers.Logistics;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Services.Logistic.Providers.Interface;
using RulerHub.Shared.DataTransferObjects.Logistic.Providers;
using RulerHub.Shared.Entities.Logistic;
using RulerHub.Shared.Localization;

namespace RulerHub.Data.Services.Logistic.Providers.Implements;

public class ProviderService(IGenericRepository<Provider> repository, IStringLocalizer<Language> Language) : IProviderService
{
    private readonly IGenericRepository<Provider> _repository = repository;
    private readonly IStringLocalizer<Language> _Language = Language;

    public async Task<ProviderDto?> CreateAsync(ProviderDto model)
    {
        try
        {
            var entity = model.ToProvider();
            var query = await _repository.Create(entity);
            if (query.Id != 0)
            {
                return query.ToProviderDto();
            }
            else
            {
                throw new TaskCanceledException(_Language["E0001"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0002"], ex);
        }
    }

    public async Task<ProviderDto?> DeleteAsync(int id)
    {
        try
        {
            var entity = await _repository.GetAll(p => p.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new KeyNotFoundException(_Language["E0003"]);
            }

            var result = await _repository.Delete(entity);
            if (result)
            {
                return entity.ToProviderDto();
            }
            else
            {
                throw new TaskCanceledException(_Language["E0004"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0005"], ex);
        }
    }

    public async Task<List<ProviderDto>> GetAsync()
    {
        try
        {
            var entities = await _repository.GetAll().ToListAsync();
            return [.. entities.Select(e => e.ToProviderDto())];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0006"], ex);
        }
    }

    public async Task<ProviderDto?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _repository.GetAll(p => p.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new KeyNotFoundException(_Language["E0003"]);
            }
            return entity.ToProviderDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0007"], ex);
        }
    }

    public async Task<ProviderDto?> UpdateAsync(int id, ProviderDto model)
    {
        try
        {
            var entity = await _repository.GetAll(p => p.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new KeyNotFoundException(_Language["E0003"]);
            }

            entity.Code = model.Code;
            entity.Name = model.Name;
            entity.Description = model.Description;

            var result = await _repository.Update(entity);
            if (result)
            {
                return entity.ToProviderDto();
            }
            else
            {
                throw new TaskCanceledException(_Language["E0008"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0009"], ex);
        }
    }
}
