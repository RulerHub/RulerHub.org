using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Logistic.Warehouses.Interfaces;
using RulerHub.Shared.Entities.Enterprises;
using RulerHub.Shared.Entities.Warehouses;
using System.Security.Claims;

namespace RulerHub.Data.Services.Logistic.Warehouses.Implements;

public class WarehouseService(
    ApplicationDbContext context,
    IHttpContextAccessor httpContextAccessor) : IWarehouseService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    private string? GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task<Enterprise?> GetEnterprise()
    {
        var userId = GetUserId();
        try
        {
            if (userId == null) return null;
            return await _context.Enterprises.FirstOrDefaultAsync(e => e.UserId == userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting enterprise: {ex.Message}");
            return null;
        }
    }

    public async Task<Warehouse?> CreateAsync(Warehouse model)
    {
        try
        {
            var enterprise = await GetEnterprise();
            if (enterprise == null)
            {
                Console.WriteLine("Enterprise not found.");
                return null;
            }
            model.EnterpriceId = enterprise.Id;
            await _context.Warehouses.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating warehouse: {ex.Message}");
            return null;
        }
    }

    public async Task<Warehouse?> DeleteAsync(int id)
    {
        try
        {
            var warehouse = await GetByIdAsync(id);
            if (warehouse is null)
            {
                return null;
            }
            if (warehouse.Departments.Count > 0 || warehouse.Departments.Count > 0 || warehouse.Items.Count > 0)
            {
                return null;
            }
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting warehouse: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Warehouse>> GetAsync()
    {
        try
        {
            var enterprise = await GetEnterprise();
            if (enterprise == null)
            {
                Console.WriteLine("Enterprise not found.");
                return [];
            }
            return await _context.Warehouses
                .Where(c => c.EnterpriceId == enterprise.Id)
                .Include(c => c.Categories)
                .Include(c => c.Departments)
                .Include(c => c.Items)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating warehouse: {ex.Message}");
            return [];
        }
    }

    public async Task<Warehouse?> GetByIdAsync(int id)
    {
        return await _context.Warehouses
            .Include(c => c.Categories)
            .Include(c => c.Departments)
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Warehouse?> UpdateAsync(int id, Warehouse model)
    {
        try
        {
            var warehouse = await GetByIdAsync(id);
            if (warehouse is null)
            {
                return null;
            }

            warehouse.Name = model.Name;
            warehouse.DateUpdate = DateTime.Now;

            await _context.SaveChangesAsync();
            return warehouse;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating warehouse: {ex.Message}");
            return null;
        }
    }
}
