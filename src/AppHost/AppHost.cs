using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent);

var postgresdb = postgres.AddDatabase("postgresdb");

var api = builder.AddProject<Backend_Api>("api")
    .WithReference(postgresdb)
    .WaitFor(postgresdb)
    .WithExternalHttpEndpoints();

var gateway = builder.AddProject<Gateway>("gateway");

builder.AddNpmApp("vue", "../Frontend")
    .WithReference(api)
    .WithReference(gateway)
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

if (builder.ExecutionContext.IsRunMode)
{
    api.WithUrlForEndpoint("https", url =>
    {
        url.DisplayText = "Scalar (HTTPS)";
        url.Url = "/scalar";
    });

    postgres.WithPgWeb(cfg =>
        cfg.WithHostPort(55555)
        .WithLifetime(ContainerLifetime.Persistent));
}

builder.Build().Run();
