var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RulerHub_Api>("rulerhub-api");

builder.AddProject<Projects.RulerHub_WebAdmin>("rulerhub-webadmin");

builder.Build().Run();
