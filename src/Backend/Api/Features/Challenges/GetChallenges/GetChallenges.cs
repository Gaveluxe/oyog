
using Backend.Api.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Features.Challenges.GetChallenges;

public sealed class GetChallengesEndpoint : EndpointWithoutRequest<IEnumerable<ChallengeResponse>, GetChallengesMapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Get("api/challenges");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var challenges = this.Context.Challenges.AsNoTracking();

        Response = Map.FromEntity(challenges);

        return Task.CompletedTask;
    }
}
