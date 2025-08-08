using Backend.Domain.ChallengeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Api.Data.Configurations;

public class GameConfigurations : IEntityTypeConfiguration<ChallengeGame>
{
    public void Configure(EntityTypeBuilder<ChallengeGame> builder)
    {
        builder.HasKey(g => g.Id);
        builder.HasIndex(g => g.ShortId).IsUnique();

        builder.Property(g => g.Status)
            .HasConversion(s => s.Value, s => GameStatus.FromValue(s));
    }
}
