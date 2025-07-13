using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.UpdateChallenge;

public sealed class Endpoint : EndpointWithMapping<UpdateChallengeRequest, UpdateChallengeResponse, Challenge>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Put("api/challenges/{challengeId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateChallengeRequest req, CancellationToken ct)
    {
        var challenge = await Context.Challenges.FindAsync(req.ChallengeId);
        if (challenge is null)
        {
            await SendNotFoundAsync();
            return;
        }

        challenge.Year = req.Year;
        await Context.SaveChangesAsync();

        Response = MapFromEntity(challenge);
    }

    public override UpdateChallengeResponse MapFromEntity(Challenge e) => new(e.Id, e.Year);
}
