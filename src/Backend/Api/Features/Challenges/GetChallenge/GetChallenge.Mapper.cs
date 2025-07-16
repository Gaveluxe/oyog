using Backend.Api.Features.Challenges.CommonModels;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.GetChallenge;

public class GetChallengeMapper : ResponseMapper<ChallengeResponse, Challenge>
{
    public override ChallengeResponse FromEntity(Challenge entity) => new()
    {
        Id = entity.Id,
        ShortId = entity.ShortId,
        Year = entity.Year,
    };
}
