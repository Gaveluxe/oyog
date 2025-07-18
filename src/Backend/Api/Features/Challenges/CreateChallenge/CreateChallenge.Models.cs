namespace Backend.Api.Features.Challenges.CreateChallenge;

public record CreateChallengeRequest
{
    public int Year { get; init; }
}

public class CreateChallengeValidator : Validator<CreateChallengeRequest>
{
    public CreateChallengeValidator()
    {
        RuleFor(cc => cc.Year).GreaterThan(0);
    }
}
