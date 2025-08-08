namespace Backend.Api.Features.Challenges.CreateChallengeGame;

public sealed class CreateChallengeGameRequest
{
    public ShortGuid ChallengeId { get; set; }

    public int Year { get; set; }
}
