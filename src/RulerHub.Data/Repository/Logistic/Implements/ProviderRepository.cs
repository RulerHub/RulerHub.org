using RulerHub.Data.Context;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Repository.Logistic.Interfaces;
using RulerHub.Shared.Entities.Logistic;

namespace RulerHub.Data.Repository.Logistic.Implements;

public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
{
    private readonly ApplicationDbContext _context;
    public ProviderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

}
