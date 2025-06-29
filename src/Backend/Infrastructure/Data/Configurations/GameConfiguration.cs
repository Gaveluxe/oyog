using Backend.Domain.ChallengeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(p => p.Name).IsRequired();

        builder.Property(p => p.Status)
            .HasConversion(
                p => p.Value,
                p => GameStatus.FromValue(p));
    }
}