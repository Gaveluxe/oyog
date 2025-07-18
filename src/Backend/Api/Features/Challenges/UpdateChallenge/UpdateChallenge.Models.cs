namespace Backend.Api.Features.Challenges.UpdateChallenge;

public sealed record UpdateChallengeRequest(ShortGuid ChallengeId, int Year);

public sealed class Validator : Validator<UpdateChallengeRequest>
{
    public Validator()
    {
        RuleFor(cc => cc.ChallengeId).NotEmpty();
        RuleFor(cc => cc.Year).GreaterThan(0);
    }
}
