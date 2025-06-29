using Backend.Domain.ChallengeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Data.Configurations;

public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.OwnsMany(c => c.Games);
    }
}