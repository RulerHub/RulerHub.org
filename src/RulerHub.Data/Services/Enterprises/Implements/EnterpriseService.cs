using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Enterprises.Interfaces;
using RulerHub.Shared.Entities.Enterprises;
using System.Security.Claims;

namespace RulerHub.Data.Services.Enterprises.Implements;

public class EnterpriseService : IEnterpriseService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EnterpriseService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    private string? GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task<List<Enterprise>> GetEnterprises()
    {
        var userId = GetUserId();
        if (userId == null) return new List<Enterprise>();

        return await _context.Enterprises.Where(e => e.UserId == userId).ToListAsync();
    }

    public async Task<Enterprise?> GetEnterprise()
    {
        var userId = GetUserId();
        if (userId == null) return null;

        return await _context.Enterprises.FirstOrDefaultAsync(e => e.UserId == userId);
    }

    public async Task<Enterprise?> GetEnterpriseById(int id)
    {
        var userId = GetUserId();
        if (userId == null) return null;

        return await _context.Enterprises.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
    }

    public async Task<Enterprise> CreateEnterprise(Enterprise enterprise)
    {
        var userId = GetUserId();
        if (userId == null) throw new UnauthorizedAccessException();

        var count = await _context.Enterprises.CountAsync(x => x.UserId == userId);

        if (count < 1)
        {
            enterprise.UserId = userId;
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();
            return enterprise;
        }
        else
        {
            throw new InvalidOperationException("El usuario ya tiene una empresa registrada.");
        }
    }

    public async Task<Enterprise?> UpdateEnterprise(Enterprise enterprise)
    {
        var userId = GetUserId();
        if (userId == null) return null;

        var existingEnterprise = await _context.Enterprises.FirstOrDefaultAsync(e => e.Id == enterprise.Id && e.UserId == userId);
        if (existingEnterprise == null) return null;

        existingEnterprise.Name = enterprise.Name;
        existingEnterprise.Description = enterprise.Description;
        existingEnterprise.Address = enterprise.Address;
        existingEnterprise.Phone = enterprise.Phone;
        existingEnterprise.Email = enterprise.Email;
        existingEnterprise.Website = enterprise.Website;

        await _context.SaveChangesAsync();
        return existingEnterprise;
    }

    public async Task<bool> DeleteEnterprise(int id)
    {
        var userId = GetUserId();
        if (userId == null) return false;

        var enterprise = await _context.Enterprises.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
        if (enterprise == null) return false;

        _context.Enterprises.Remove(enterprise);
        await _context.SaveChangesAsync();
        return true;
    }
}
