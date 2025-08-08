namespace Backend.Domain.ChallengeAggregate;

public class ChallengeGame : BaseEntity
{
    public string ShortId { get; set; }

    public Guid ChallengeId { get; set; }

    public string? Name { get; set; }

    public int Year { get; set; }

    public GameStatus Status { get; set; }

    public Challenge? Challenge { get; set; }

    public ChallengeGame(int year)
    {
        this.Id = Guid.CreateVersion7();
        this.ShortId = ShortGuid.Encode(this.Id);
        this.Year = year;
        this.Status = GameStatus.NotStarted;
    }
}
