using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;
using Backend.Domain.Common;

namespace Backend.Api.Features.Challenges.GetChallenges;

public sealed class GetChallengesMapper: ResponseMapper<IEnumerable<ChallengeResponse>, IEnumerable<Challenge>>
{
    public override IEnumerable<ChallengeResponse> FromEntity(IEnumerable<Challenge> entities) =>
        entities.Select(e => new ChallengeResponse()
        {
            Id = e.Id,
            ShortId = e.ShortId,
            Year = e.Year,
        });
}
