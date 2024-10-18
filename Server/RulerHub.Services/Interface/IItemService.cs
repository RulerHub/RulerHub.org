using RulerHub.Services.Helpers;
using RulerHub.Shared.DataTransferObjects.Item;
using RulerHub.Shared.DbModels;

namespace RulerHub.Services.Interface;

public interface IItemService
{
    // Get All Category Method
    Task<List<ItemModel>> GetItemAsync(QueryItem query);
    // Get by id method
    Task<ItemModel?> GetByIdAsync(int id);
    // Create Method
    Task<ItemModel?> CreateAsync(ItemModel model);
    // Update category Method
    Task<ItemModel?> UpdateAsync(int id, UpdateItemDto model);
    // Delete category Method
    Task<ItemModel> DeleteAsync(int id);
}
