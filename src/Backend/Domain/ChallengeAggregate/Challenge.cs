using System.Text.Json;

namespace Backend.Domain.ChallengeAggregate;

public sealed class Challenge : BaseEntity, IAggregateRoot, IDisposable
{
    public int Year { get; set; }

    public ICollection<Game> Games { get; set; }

    public JsonDocument Fields { get; set; } = JsonDocument.Parse("{}");

    public Challenge()
    {
        this.Games = [];
        this.Fields = JsonDocument.Parse("{}");
    }

    public Game AddGame(string name, int year)
    {
        var newGame = new Game
        {
            Name = name,
            Year = year,
            Status = GameStatus.NotStarted,
        };

        this.Games.Add(newGame);

        return newGame;
    }

    public void Dispose() => Fields.Dispose();
}