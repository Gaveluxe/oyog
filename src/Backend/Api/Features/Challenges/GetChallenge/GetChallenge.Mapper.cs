using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.GetChallenge;

public class GetChallengeMapper : ResponseMapper<GetChallengeResponse, Challenge>
{
    public override GetChallengeResponse FromEntity(Challenge entity) => new()
    {
        Id = entity.Id,
        ShortId = entity.ShortId,
        Username = entity.Username,
        Year = entity.Year,
        Games = entity.Games.Select(g => new GameResponse()
        {
            ShortId = g.ShortId,
            Name = g.Name,
            Status = g.Status.Name,
            Year = g.Year,
        }),
    };
}
