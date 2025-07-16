
namespace Backend.Api.Features.Challenges.GetChallenges;

public sealed class GetChallengesEndpoint : EndpointWithoutRequest<IEnumerable<GetChallengesResponse>, GetChallengesMapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Get("api/challenges");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var challenges = this.Context.Challenges;
        Response = Map.FromEntity(challenges);
        
        return Task.CompletedTask;
    }
}

