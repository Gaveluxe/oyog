namespace Backend.Api.Data.Helpers;

internal class DbInitializer(AppDbContext context)
{
    private readonly AppDbContext context = context;

    /// <summary>
    /// Ensure database is created and seeded with test data
    /// </summary>
    public async Task RunAsync()
    {
        await this.context.Database.EnsureCreatedAsync();
        
        await this.SeedAsync();
    }

    private async Task SeedAsync()
    {
        await context.Challenges.AddAsync(new()
        {
            Year = 2025,
        });

        await context.SaveChangesAsync();
    }
}
