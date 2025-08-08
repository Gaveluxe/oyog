using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.GetChallenges;

public sealed class GetChallengesMapper : ResponseMapper<IEnumerable<ChallengeResponse>, IEnumerable<Challenge>>
{
    public override IEnumerable<ChallengeResponse> FromEntity(IEnumerable<Challenge> entities) =>
        entities.Select(e => new ChallengeResponse()
        {
            Id = e.Id,
            ShortId = e.ShortId,
            Username = e.Username,
            Year = e.Year,
        });
}
