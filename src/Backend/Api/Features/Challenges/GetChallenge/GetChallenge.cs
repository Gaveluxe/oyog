using Backend.Api.Common.Dtos;

namespace Backend.Api.Features.Challenges.GetChallenge;

public sealed class GetChallengeEndpoint : Endpoint<GetChallengeRequest, ChallengeResponse, GetChallengeMapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Get("/api/challenges/{challengeId:shortguid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetChallengeRequest req, CancellationToken ct)
    {
        var challenge = await this.Context.Challenges.FindAsync((Guid)req.ChallengeId, ct);
        if (challenge is null)
        {
            await Send.NotFoundAsync();
            return;
        }

        Response = Map.FromEntity(challenge);
    }
}
