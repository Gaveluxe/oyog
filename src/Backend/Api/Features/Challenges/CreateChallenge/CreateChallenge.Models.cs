namespace Backend.Api.Features.Challenges.CreateChallenge;

public record CreateChallengeRequest
{
    public required string Username { get; init; }

    public required int Year { get; init; }
}

public class CreateChallengeValidator : Validator<CreateChallengeRequest>
{
    public CreateChallengeValidator()
    {
        RuleFor(cc => cc.Username).NotEmpty();
        RuleFor(cc => cc.Year).GreaterThan(0);
    }
}
