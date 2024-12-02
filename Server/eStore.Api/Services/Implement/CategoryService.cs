using eStore.Api.Data;
using eStore.Api.DataTransferObjets.CategoryDtos;
using eStore.Api.Entities;
using eStore.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace eStore.Api.Services.Implement;

public class CategoryService(ApplicationDbContext context) : ICategoryService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Category?> CreateAsync(Category model)
    {
        await _context.Categories.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Category> DeleteAsync(int id)
    {
        var query = await GetByIdAsync(id);
        if (query is null)
        {
            return null;
        }
        _context.Categories.Remove(query);
        await _context.SaveChangesAsync();
        return query;
    }

    public async Task<List<Category>> GetAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> UpdateAsync(int id, UpdateCategoryDto model)
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


public static class CategoryEndpoints
{
	public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Category").WithTags(nameof(Category));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Categories.ToListAsync();
        })
        .WithName("GetAllCategories")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Category>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Categories.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Category model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCategoryById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Category category, ApplicationDbContext db) =>
        {
            var affected = await db.Categories
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, category.Id)
                  .SetProperty(m => m.Name, category.Name)
                  .SetProperty(m => m.Description, category.Description)
                  .SetProperty(m => m.CreateDate, category.CreateDate)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCategory")
        .WithOpenApi();

        group.MapPost("/", async (Category category, ApplicationDbContext db) =>
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Category/{category.Id}",category);
        })
        .WithName("CreateCategory")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApplicationDbContext db) =>
        {
            var affected = await db.Categories
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCategory")
        .WithOpenApi();
    }
}
