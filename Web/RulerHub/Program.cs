using Aspire.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using RulerHub;
using RulerHub.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
ServicesConfiguration.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

ServicesConfiguration.ConfigureLocalization(app);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

ServicesConfiguration.ConfigureMiddleware(app);

app.Run();

