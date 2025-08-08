using Backend.Api.Common.Dtos;

namespace Backend.Api.Features.Challenges.GetChallenge;

public record GetChallengeRequest(ShortGuid ChallengeId);

public class GetChallengeResponse : ChallengeResponse
{
    public required IEnumerable<GameResponse> Games { get; set; } = [];
}
