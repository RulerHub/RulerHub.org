using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RulerHub.Shared.Entities.Enterprises;
using RulerHub.Shared.Entities.Identity;
using RulerHub.Shared.Entities.Logistic;
using RulerHub.Shared.Entities.Sales;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // ToDo: Crear la relacion 1 a 1
    public DbSet<Enterprise> Enterprises { get; set; }

    public DbSet<Provider> Providers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Return> Returns { get; set; }
    // Sales
    public DbSet<Department> Departments { get; set; }
    // Warehouse
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
}
