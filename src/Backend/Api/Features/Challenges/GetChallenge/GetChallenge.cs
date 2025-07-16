using Backend.Api.Features.Challenges.CommonModels;

namespace Backend.Api.Features.Challenges.GetChallenge;

public sealed class GetChallengeEndpoint : Endpoint<GetChallengeRequest, ChallengeResponse, GetChallengeMapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Get("/api/challenges/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetChallengeRequest req, CancellationToken ct)
    {
        var challenge = await this.Context.Challenges.FindAsync(req.Id);
        if (challenge is null)
        {
            await SendNotFoundAsync();
            return;
        }

        Response = Map.FromEntity(challenge);
    }
}
