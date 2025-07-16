using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");

var api = builder.AddProject<Backend_Api>("api")
    .WithReference(postgresdb)
    .WaitFor(postgresdb)
    .WithExternalHttpEndpoints();

builder.AddNpmApp("vue", "../Frontend")
    .WithReference(api)
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

if (builder.ExecutionContext.IsRunMode)
{
    postgres.WithPgWeb(cfg => cfg.WithHostPort(55555));
}

builder.Build().Run();
