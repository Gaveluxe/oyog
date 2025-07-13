using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.GetChallenges;

public record GetChallengesResponse(Guid Id, int Year);

public sealed class GetChallengesMapper: ResponseMapper<IEnumerable<GetChallengesResponse>, IEnumerable<Challenge>>
{
    public override IEnumerable<GetChallengesResponse> FromEntity(IEnumerable<Challenge> entities) =>
        entities.Select(e => new GetChallengesResponse(e.Id, e.Year));
}
