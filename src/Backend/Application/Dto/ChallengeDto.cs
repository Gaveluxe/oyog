namespace Backend.Application.Dto;

public class ChallengeDto
{
    public Guid Id { get; set; }
    
    public int Year { get; set; }

    public static ChallengeDto FromEntity(Challenge challenge)
    {
        return new ChallengeDto
        {
            Id = challenge.Id,
            Year = challenge.Year,
        };
    }
}