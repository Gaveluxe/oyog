namespace Backend.Domain.ChallengeAggregate;

public sealed class Challenge : BaseEntity, IAggregateRoot
{
    public string ShortId { get; set; }

    public string Username { get; set; }

    public int Year { get; set; }

    public Challenge(string username, int year)
    {
        this.Id = Guid.CreateVersion7();
        this.ShortId = ShortGuid.Encode(this.Id);
        this.Username = username;
        this.Year = year;
    }
}
