using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");

builder.AddProject<Backend_Api>("api")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

if (builder.ExecutionContext.IsRunMode)
{
    postgres.WithPgWeb(cfg => cfg.WithHostPort(55555));
}

builder.Build().Run();
