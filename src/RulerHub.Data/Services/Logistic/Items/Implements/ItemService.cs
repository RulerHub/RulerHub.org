using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Logistic.Items.Interfaces;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Data.Services.Logistic.Items.Implements;

public class ItemService(ApplicationDbContext context) : IItemService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Item?> CreateAsync(Item model)
    {
        try
        {
            await _context.Items.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating item: {ex.Message}");
            return null;
        }
    }

    public async Task<Item> DeleteAsync(int id)
    {
        try
        {
            var query = await GetByIdAsync(id);
            if (query is null)
            {
                return null;
            }
            _context.Items.Remove(query);
            await _context.SaveChangesAsync();
            return query;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting item: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Item>> GetAsync()
    {
        try
        {
            return await _context.Items.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving items: {ex.Message}");
            return new List<Item>();
        }
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Items.FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving item by id: {ex.Message}");
            return null;
        }
    }

    public async Task<Item?> UpdateAsync(int id, Item model)
    {
        try
        {
            var query = await GetByIdAsync(id);
            if (query is null)
            {
                return null;
            }

            query.Code = model.Code;
            query.Name = model.Name;
            query.Description = model.Description;
            query.MeasureUnit = model.MeasureUnit;

            await _context.SaveChangesAsync();
            return query;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating item: {ex.Message}");
            return null;
        }
    }
}
