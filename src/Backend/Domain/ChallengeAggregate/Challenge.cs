namespace Backend.Domain.ChallengeAggregate;

public sealed class Challenge : BaseEntity, IAggregateRoot
{
    public string ShortId { get; set; }

    public string Username { get; set; }

    public int Year { get; set; }

    public List<ChallengeGame> Games { get; set; }

    public Challenge(string username, int year)
    {
        this.Id = Guid.CreateVersion7();
        this.ShortId = ShortGuid.Encode(this.Id);
        this.Username = username;
        this.Year = year;
        this.Games = [];
    }

    public Challenge(string username, int year, int fromYear)
        : this(username, year)
    {
        var games = Enumerable.Range(fromYear, year - fromYear).Select(i => new ChallengeGame(i));
        this.Games.AddRange(games);
    }

    public ChallengeGame AddGame(int year)
    {
        ChallengeGame game = new(year);
        this.Games.Add(game);
        return game;
    }
}
