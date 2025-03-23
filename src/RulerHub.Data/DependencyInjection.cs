using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulerHub.Data.Context;
using RulerHub.Data.Services.Enterprises.Implements;
using RulerHub.Data.Services.Enterprises.Interfaces;
using RulerHub.Data.Services.Logistic.Items.Implements;
using RulerHub.Data.Services.Logistic.Items.Interfaces;
using RulerHub.Data.Services.Logistic.Warehouses.Implements;
using RulerHub.Data.Services.Logistic.Warehouses.Interfaces;

namespace RulerHub.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<IEnterpriseService, EnterpriseService>();
        // Logistic
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IWarehouseService, WarehouseService>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Db context configuration
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}
