using eStore.Api.Data;
using eStore.Api.DataTransferObjets.ProductDtos;
using eStore.Api.Entities;
using eStore.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eStore.Api.Services.Implement;

public class ProductService(ApplicationDbContext context) : IProductService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Product?> CreateAsync(Product model)
    {
        await _context.Products.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }
        _context.Products.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<List<Product>> GetAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Product?> UpdateAsync(int id, UpdateProductDto model)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }

        query.Name = model.Name;
        query.Description = model.Description;

        await _context.SaveChangesAsync();
        return query;
    }
}
