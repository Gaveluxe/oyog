namespace Backend.Api.Features.Challenges.UpdateChallenge;

public sealed record UpdateChallengeRequest(Guid ChallengeId, int Year);

public sealed class Validator : Validator<UpdateChallengeRequest>
{
    public Validator()
    {
        RuleFor(cc => cc.ChallengeId).NotEmpty();
        RuleFor(cc => cc.Year).GreaterThan(0);
    }
}

public sealed record UpdateChallengeResponse(Guid Id, int Year);
