using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using RulerHub.Data.Mappers.Logistics;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Services.Logistic.Categories.Interfaces;
using RulerHub.Shared.DataTransferObjects.Logistic.Categories;
using RulerHub.Shared.Entities.Warehouses;
using RulerHub.Shared.Localization;

namespace RulerHub.Data.Services.Logistic.Categories.Implements;

public class CategoryService(IGenericRepository<Category> repository, IStringLocalizer<Language> Language) : ICategoryService
{
    private readonly IGenericRepository<Category> _repository = repository;
    private readonly IStringLocalizer<Language> _Language = Language;

    public async Task<CategoryDto?> CreateAsync(CategoryDto model)
    {
        try
        {
            var entity = model.ToCategory();
            var query = await _repository.Create((Category)entity);
            if (query.Id != 0)
            {
                return query.ToCategoryDto();
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

    public async Task<CategoryDto?> DeleteAsync(int id)
    {
        try
        {
            var entity = await _repository.GetAll(p => p.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException(_Language["E0003"]);
            var result = await _repository.Delete(entity);
            if (result)
            {
                return entity.ToCategoryDto();
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

    public async Task<List<CategoryDto>> GetAsync()
    {
        try
        {
            var entities = await _repository.GetAll().ToListAsync();
            return [.. entities.Select(e => e.ToCategoryDto())];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0006"], ex);
        }
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _repository.GetAll(p => p.Id == id).FirstOrDefaultAsync();
            return entity == null ? throw new KeyNotFoundException(_Language["E0003"]) : entity.ToCategoryDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new Exception(_Language["E0007"], ex);
        }
    }

    public async Task<CategoryDto?> UpdateAsync(int id, CategoryDto model)
    {
        try
        {
            var entity = await _repository.GetAll(p => p.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException(_Language["E0003"]);
            entity.Name = model.Name;
            entity.Description = model.Description;

            var result = await _repository.Update(entity);
            if (result)
            {
                return entity.ToCategoryDto();
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
