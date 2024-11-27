var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RulerHub>("rulerhub");

builder.Build().Run();
