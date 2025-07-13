using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.CreateChallenge;

public sealed class CreateChallengeEndpoint : EndpointWithMapping<CreateChallengeRequest, CreateChallengeResponse, Challenge>
{
    public required AppDbContext DbContext { get; set; }

    public override void Configure()
    {
        Post("api/challenges");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateChallengeRequest req, CancellationToken ct)
    {
        Challenge challenge = MapToEntity(req);
        await DbContext.AddAsync(challenge);
        await DbContext.SaveChangesAsync();

        Response = MapFromEntity(challenge);
    }
    
    public override Challenge MapToEntity(CreateChallengeRequest req) => new()
    {
        Year = req.Year,
    };

    public override CreateChallengeResponse MapFromEntity(Challenge entity) => new(entity.Id, entity.Year);
}
