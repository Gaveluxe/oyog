using Backend.Domain.ChallengeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Api.Data.Configurations;

public class ChallengeConfigurations : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.ShortId).IsUnique();

        builder.HasMany(c => c.Games).WithOne(g => g.Challenge);
    }
}
