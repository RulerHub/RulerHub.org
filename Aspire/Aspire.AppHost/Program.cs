using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var eStoreApi = builder.AddProject<Projects.eStore_Api>("eStoreApi");

builder.AddProject<Projects.RulerHub>("RulerHub")
    .WithExternalHttpEndpoints()
    .WithReference(eStoreApi)
    .WaitFor(eStoreApi);

builder.AddProject<Projects.eStore_Web>("eStoreWeb")
    .WithExternalHttpEndpoints()
    .WithReference(eStoreApi)
    .WaitFor(eStoreApi);

builder.Build().Run();
