using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Backend_Api>("api");

builder.Build().Run();
