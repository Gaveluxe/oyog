using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Common.Dtos;

public class GameResponse
{
    public required string? Name { get; init; }

    public required string ShortId { get; set; }

    public required int Year { get; init; }

    public required string Status { get; init; }

    public sealed class Mapper : ResponseMapper<GameResponse, ChallengeGame>
    {
        public override GameResponse FromEntity(ChallengeGame e)
        {
            return new GameResponse
            {
                Name = e.Name,
                ShortId = e.ShortId,
                Year = e.Year,
                Status = e.Status
            };
        }
    }

    public sealed class CollectionMapper : ResponseMapper<IEnumerable<GameResponse>, IEnumerable<ChallengeGame>>
    {
        public override IEnumerable<GameResponse> FromEntity(IEnumerable<ChallengeGame> e)
        {
            return e.Select(g => new GameResponse
            {
                Name = g.Name,
                ShortId = g.ShortId,
                Year = g.Year,
                Status = g.Status
            });
        }
    }
}
