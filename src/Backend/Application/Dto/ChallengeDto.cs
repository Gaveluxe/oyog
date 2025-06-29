namespace Backend.Application.Dto;

public class ChallengeDto
{
    public Guid Id { get; init; }
    
    public int Year { get; init; }

    public static ChallengeDto FromEntity(Challenge challenge)
    {
        return new ChallengeDto
        {
            Id = challenge.Id,
            Year = challenge.Year,
        };
    }
}