using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RulerHub.Data.Identity;
using RulerHub.Shared.DbModels;

namespace RulerHub.Data;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
{
    // Db Models
    public DbSet<CategoryModel> CategoryDbs { get; set; }
    public DbSet<ItemModel> ItemDbs { get; set; }
}
