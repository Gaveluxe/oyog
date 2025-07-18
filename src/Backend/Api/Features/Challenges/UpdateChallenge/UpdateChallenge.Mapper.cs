using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.UpdateChallenge;

public class UpdateChallengeMapper : ResponseMapper<ChallengeResponse, Challenge>
{
    public override ChallengeResponse FromEntity(Challenge entity) => new()
    {
        Id = entity.Id,
        ShortId = entity.ShortId,
        Username = entity.Username,
        Year = entity.Year,
    };
}
