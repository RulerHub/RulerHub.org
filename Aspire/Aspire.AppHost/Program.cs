var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RulerHub>("RulerHub");
//.WithExternalHttpEndpoints()
//.WithReference(eStoreApi)
//.WaitFor(eStoreApi)

builder.Build().Run();
