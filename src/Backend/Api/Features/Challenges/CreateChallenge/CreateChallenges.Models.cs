namespace Backend.Api.Features.Challenges.CreateChallenge;

public record CreateChallengeRequest(int Year) {}

public class CreateChallengeValidator : Validator<CreateChallengeRequest>
{
    public CreateChallengeValidator()
    {
        RuleFor(cc => cc.Year).GreaterThan(0);
    }
}

public record CreateChallengeResponse(Guid Id, int Year) { }
