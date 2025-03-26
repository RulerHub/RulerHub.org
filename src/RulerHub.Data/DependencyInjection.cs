using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulerHub.Data.Context;
using RulerHub.Data.Repository.Generic;
using RulerHub.Data.Repository.Logistic.Implements;
using RulerHub.Data.Repository.Logistic.Interfaces;
using RulerHub.Data.Services.Enterprises.Implements;
using RulerHub.Data.Services.Enterprises.Interfaces;
using RulerHub.Data.Services.Logistic.Items.Implements;
using RulerHub.Data.Services.Logistic.Items.Interfaces;
using RulerHub.Data.Services.Logistic.Providers.Implements;
using RulerHub.Data.Services.Logistic.Providers.Interface;
using RulerHub.Data.Services.Logistic.Warehouses.Implements;
using RulerHub.Data.Services.Logistic.Warehouses.Interfaces;
using RulerHub.Data.Services.Tools;

namespace RulerHub.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        // TODO: Add services here
        services.AddLocalization();
        services.AddControllers();
        
        services.AddScoped<IEnterpriseService, EnterpriseService>();
        // Logistic
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IWarehouseService, WarehouseService>();
        services.AddScoped<IProviderService, ProviderService>();
        // Tools
        services.AddScoped<PdfService>();

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProviderRepository, ProviderRepository>();

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
