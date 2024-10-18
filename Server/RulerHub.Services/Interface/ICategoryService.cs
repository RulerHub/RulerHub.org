using RulerHub.Shared.DataTransferObjects.Category;
using RulerHub.Shared.DbModels;

namespace RulerHub.Services.Interface;

public interface ICategoryService
{
    // Get All Category Method
    Task<List<CategoryModel>> GetCategoryAsync();
    // Get by id method
    Task<CategoryModel?> GetByIdAsync(int id);
    // Create Method
    Task<CategoryModel?> CreateAsync(CategoryModel model);
    // Update category Method
    Task<CategoryModel?> UpdateAsync(int id, UpdateCategoryDto model);
    // Delete category Method
    Task<CategoryModel> DeleteAsync(int id);
}
