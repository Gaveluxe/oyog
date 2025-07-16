namespace Backend.Api.Features.Challenges.CommonModels;

public class ChallengeResponse
{
    public required Guid Id { get; init; }

    public required string ShortId { get; init; }

    public required int Year { get; init; }
}
