using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Logistic.Providers.Interface;
using RulerHub.Shared.Entities.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Data.Services.Logistic.Providers.Implements;

public class ProviderService(
    ApplicationDbContext context,
    IHttpContextAccessor httpContextAccessor) : IProviderService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    private string? GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task<Provider?> CreateAsync(Provider model)
    {
        try
        {
            await _context.Providers.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating provider: {ex.Message}");
            return null;
        }
    }

    public async Task<Provider?> DeleteAsync(int id)
    {
        try
        {
            var query = await GetByIdAsync(id);
            if (query is null)
            {
                return null;
            }
            if (query.Purchases.Count > 0)
            {
                return null;
            }
            _context.Providers.Remove(query);
            await _context.SaveChangesAsync();
            return query;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting provider: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Provider>> GetAsync()
    {
        try
        {
            return await _context.Providers
                .Include(c => c.Purchases)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo provider: {ex.Message}");
            return [];
        }
    }

    public async Task<Provider?> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Providers
            .Include(c => c.Purchases)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo provider: {ex.Message}");
            return null;
        }
        
    }

    public async Task<Provider?> UpdateAsync(int id, Provider model)
    {
        try
        {
            var query = await GetByIdAsync(id);
            if (query is null)
            {
                return null;
            }

            query.Name = model.Name;
            query.Description = model.Description;    
            query.DateUpdate = DateTime.Now;

            await _context.SaveChangesAsync();
            return query;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating provider: {ex.Message}");
            return null;
        }
    }
}
