using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.CreateChallenge;

public sealed class CreateChallengeEndpoint : Endpoint<CreateChallengeRequest, ChallengeResponse, CreateChallengeMapper>
{
    public required AppDbContext DbContext { get; set; }

    public override void Configure()
    {
        Post("api/challenges");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateChallengeRequest req, CancellationToken ct)
    {
        this.Logger.LogInformation("Creating challenge");

        Challenge challenge = Map.ToEntity(req);
        await DbContext.AddAsync(challenge);
        await DbContext.SaveChangesAsync();

        Response = Map.FromEntity(challenge);
    }
}
