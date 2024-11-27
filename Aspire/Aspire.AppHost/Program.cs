var builder = DistributedApplication.CreateBuilder(args);

var mainPaage = builder.AddProject<Projects.RulerHub>("rulerhub");

builder.Build().Run();
