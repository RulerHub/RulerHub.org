using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var eStoreApi = builder.AddProject<Projects.eStore_Api>("eSstoreApi");

builder.AddProject<Projects.RulerHub>("RulerHub")
    .WithExternalHttpEndpoints()
    .WithReference(eStoreApi)
    .WaitFor(eStoreApi);

builder.Build().Run();
