namespace Backend.Api.Data.Helpers;

internal class DbInitializer(AppDbContext context)
{
    private readonly AppDbContext context = context;

    public void Run()
    {
        this.context.Database.EnsureCreated();
    }
}