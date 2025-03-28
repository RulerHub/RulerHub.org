using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RulerHub.Shared.Entities.Enterprises;
using RulerHub.Shared.Entities.Identity;

namespace RulerHub.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // ToDo: Crear la relacion 1 a 1
    public DbSet<Enterprise> Enterprises { get; set; }
}
