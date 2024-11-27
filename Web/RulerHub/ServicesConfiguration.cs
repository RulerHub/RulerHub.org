using Microsoft.EntityFrameworkCore;
using RulerHub.Data;

namespace RulerHub;

public static class ServicesConfiguration
{
    // Global services
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddControllers();

        return services;
    }

    // Db services
    public static void ConfigureDbServices(IConfiguration configuration, IServiceCollection services)
    {

        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

    }
}
