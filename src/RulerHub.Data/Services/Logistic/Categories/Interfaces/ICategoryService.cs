using RulerHub.Shared.DataTransferObjects.Logistic.Categories;

namespace RulerHub.Data.Services.Logistic.Categories.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAsync();
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<CategoryDto?> CreateAsync(CategoryDto model);
    Task<CategoryDto?> UpdateAsync(int id, CategoryDto model);
    Task<CategoryDto?> DeleteAsync(int id);
}
