using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");

var api = builder.AddProject<Backend_Api>("api")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

// Add configurations to help local development
if (builder.ExecutionContext.IsRunMode)
{
    postgres.WithPgWeb(pgweb => pgweb.WithHostPort(55555));

    var endpoint = api.Resource.GetEndpoint("https");
    api.WithUrls(x => x.Urls.Add(new()
    {
        Url = $"{endpoint.Url}/scalar",
        DisplayText = "Scalar UI"
    }));
}

builder.Build().Run();
