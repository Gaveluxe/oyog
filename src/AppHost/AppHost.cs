using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("postgresdb");
if (builder.ExecutionContext.IsRunMode)
{
    postgres.WithPgWeb();
}

var api = builder.AddProject<Backend_Api>("api")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

if (builder.ExecutionContext.IsRunMode)
{
    var endpoint = api.Resource.GetEndpoint("https");
    api.WithUrls(x => x.Urls.Add(new ResourceUrlAnnotation
    {
        Url = $"{endpoint.Url}/scalar",
        DisplayText = "Scalar UI"
    }));
}

builder.Build().Run();
