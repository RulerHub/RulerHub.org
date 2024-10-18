using Microsoft.EntityFrameworkCore;
using RulerHub.Data;
using RulerHub.Services.Interface;
using RulerHub.Shared.DataTransferObjects.Category;
using RulerHub.Shared.DbModels;


namespace RulerHub.Services.Implement;

public class CategoryService(ApplicationDbContext context) : ICategoryService
{
    private readonly ApplicationDbContext _context = context;
    // create method implementation 
    public async Task<CategoryModel?> CreateAsync(CategoryModel model)
    {
        await _context.CategoryDbs.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }
    // Delete method implementation
    public async Task<CategoryModel> DeleteAsync(int id)
    {
        var query = await _context.CategoryDbs.FirstOrDefaultAsync(i => i.Id == id);
        if (query is null)
        {
            return null;
        }
        _context.CategoryDbs.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }
    // get by id method implementation
    public async Task<CategoryModel?> GetByIdAsync(int id)
    {
        return await _context.CategoryDbs.Include(i => i.Items).FirstOrDefaultAsync(c => c.Id == id);
    }
    // Get Categories method implementation
    public async Task<List<CategoryModel>> GetCategoryAsync()
    {
        return await _context.CategoryDbs.Include(i => i.Items).ToListAsync();
    }
    // Update category method implementation
    public async Task<CategoryModel?> UpdateAsync(int id, UpdateCategoryDto model)
    {
        var query = await _context.CategoryDbs.FirstOrDefaultAsync(i => i.Id == id);
        if (query is null)
        {
            return null;
        }
        query.Name = model.Name;
        query.Description = model.Description!;

        await _context.SaveChangesAsync();
        return query;
    }
}
