using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.UpdateChallengeGame;

public sealed class UpdateChallengeGameRequest
{
    public ShortGuid ChallengeId { get; set; }

    public ShortGuid GameId { get; set; }
    public int Year { get; set; }

    public string? Name { get; set; }

    public required string Status { get; set; }
}
