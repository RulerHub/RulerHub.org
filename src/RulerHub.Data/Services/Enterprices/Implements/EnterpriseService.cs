using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Enterprices.Interfaces;
using RulerHub.Shared.Entities.Enterprices;

namespace RulerHub.Data.Services.Enterprices.Implements;

public class EnterpriseService : IEnterpriseService
{
    private readonly ApplicationDbContext _context;
    public EnterpriseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Enterprice>> GetEnterprices()
    {
        return await _context.Enterprices.ToListAsync();
    }
}
