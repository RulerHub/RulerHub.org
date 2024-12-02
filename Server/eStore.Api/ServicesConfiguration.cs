using eStore.Api.Data;
using eStore.Api.Services.Implement;
using eStore.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eStore.Api;

public static class ServicesConfiguration
{
    // Global services
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }

    // Db services
    public static void ConfigureDbServices(IConfiguration configuration, IServiceCollection services)
    {

        //var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(connectionString));
        //services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                        .ConfigureWarnings(warnings => warnings
                        .Ignore(RelationalEventId.PendingModelChangesWarning)));

    }
}
