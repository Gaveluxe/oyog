using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Data.Helpers;

internal class DbInitializer(AppDbContext context)
{
    private readonly AppDbContext context = context;

    /// <summary>
    /// Ensure database is created and seeded with test data
    /// </summary>
    public async Task RunAsync()
    {
        await this.context.Database.EnsureDeletedAsync();
        await this.context.Database.EnsureCreatedAsync();

        await this.SeedAsync();
    }

    private async Task SeedAsync()
    {
        var challenge1 = new Challenge("Gaveluxe", 2024);
        var challenge2 = new Challenge("Gaveluxe", 2025);

        var game = challenge2.AddGame(2025);
        game.Name = "Mindseye";

        await context.Challenges.AddRangeAsync(challenge1, challenge2);
        await context.SaveChangesAsync();
    }
}
