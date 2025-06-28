using Backend.Domain.ChallengeAggregate;

using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Challenge> Challenges { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}