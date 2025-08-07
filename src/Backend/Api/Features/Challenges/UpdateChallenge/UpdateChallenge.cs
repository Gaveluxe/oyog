using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.UpdateChallenge;

public sealed class Endpoint : Endpoint<UpdateChallengeRequest, ChallengeResponse, UpdateChallengeMapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        this.Put("api/challenges/{challengeId}");
        this.AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateChallengeRequest req, CancellationToken ct)
    {
        Challenge? challenge = await this.Context.Challenges.FindAsync((Guid)req.ChallengeId);
        if (challenge is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        challenge.Year = req.Year;
        await this.Context.SaveChangesAsync();

        this.Response = this.Map.FromEntity(challenge);
    }
}
