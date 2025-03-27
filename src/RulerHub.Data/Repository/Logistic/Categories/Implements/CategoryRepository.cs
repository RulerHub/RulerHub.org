using RulerHub.Data.Context;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Repository.Logistic.Categories.Interfaces;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Data.Repository.Logistic.Categories.Implements;

public class CategoryRepository(ApplicationDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
    private readonly ApplicationDbContext _context = context;
}
