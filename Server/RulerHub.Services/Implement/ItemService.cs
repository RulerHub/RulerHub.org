
using Microsoft.EntityFrameworkCore;
using RulerHub.Data;
using RulerHub.Services.Helpers;
using RulerHub.Services.Interface;
using RulerHub.Shared.DataTransferObjects.Item;
using RulerHub.Shared.DbModels;

namespace RulerHub.Services.Implement;

public class ItemService(ApplicationDbContext context) : IItemService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ItemModel?> CreateAsync(ItemModel model)
    {
        await _context.ItemDbs.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<ItemModel> DeleteAsync(int id)
    {
        var query = await _context.ItemDbs.FirstOrDefaultAsync(i => i.Id == id);
        if (query is null)
        {
            return null;
        }
        _context.ItemDbs.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<ItemModel?> GetByIdAsync(int id)
    {
        return await _context.ItemDbs.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<ItemModel>> GetItemAsync(QueryItem query)
    {
        var items = _context.ItemDbs.AsQueryable();
        // Filtering
        if (!string.IsNullOrWhiteSpace(query.Code))
        {
            items = items.Where(s => s.Code.Contains(query.Code));
        }
        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            items = items.Where(s => s.Name.Contains(query.Name));
        }
        // Sorting
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                items = query.IsDescending ? items.OrderByDescending(s => s.Name) : items.OrderBy(s => s.Name);
            }
        }
        // Pagination
        var skipNumber = (query.PageNumber - 1) * query.PageSize;
        return await items.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<ItemModel?> UpdateAsync(int id, UpdateItemDto model)
    {
        var query = await _context.ItemDbs.FirstOrDefaultAsync(i => i.Id == id);
        if (query is null)
        {
            return null;
        }
        query.Name = model.Name;
        query.Description = model.Description!;
        query.Price = model.Price;

        await _context.SaveChangesAsync();
        return query;
    }
}
