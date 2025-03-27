using RulerHub.Data.Context;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Repository.Logistic.Providers.Interfaces;
using RulerHub.Shared.Entities.Logistic;

namespace RulerHub.Data.Repository.Logistic.Providers.Implements;

public class ProviderRepository(ApplicationDbContext context) : GenericRepository<Provider>(context), IProviderRepository
{
    private readonly ApplicationDbContext _context = context;
}
