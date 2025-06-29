using System.Reflection;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Challenge> Challenges => Set<Challenge>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        model.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}