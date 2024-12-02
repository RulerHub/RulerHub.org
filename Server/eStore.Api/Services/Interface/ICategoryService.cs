using eStore.Api.DataTransferObjets.CategoryDtos;
using eStore.Api.Entities;

namespace eStore.Api.Services.Interface;

public interface ICategoryService
{
    Task<List<Category>> GetAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> CreateAsync(Category model);
    Task<Category?> UpdateAsync(int id, UpdateCategoryDto model);
    Task<Category> DeleteAsync(int id);
}
