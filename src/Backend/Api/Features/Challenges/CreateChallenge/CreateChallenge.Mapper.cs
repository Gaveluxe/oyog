using Backend.Api.Common.Dtos;
using Backend.Domain.ChallengeAggregate;

namespace Backend.Api.Features.Challenges.CreateChallenge;

public class CreateChallengeMapper : Mapper<CreateChallengeRequest, ChallengeResponse, Challenge>
{
    public override Challenge ToEntity(CreateChallengeRequest req) => new(req.Username, req.Year);

    public override ChallengeResponse FromEntity(Challenge entity) => new()
    {
        Id = entity.Id,
        Username = entity.Username,
        Year = entity.Year,
        ShortId = entity.ShortId,
    };
}
