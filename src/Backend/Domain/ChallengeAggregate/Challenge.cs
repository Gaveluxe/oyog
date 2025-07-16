namespace Backend.Domain.ChallengeAggregate;

public sealed class Challenge : BaseEntity, IAggregateRoot
{
    public int Year { get; set; }

    // public List<Game> Games { get; set; }

    // public List<FieldDefinition> FieldsDefinition { get; set; } = [];

    // public Challenge()
    // {
    //     this.Games = [];
    //     this.FieldsDefinition = [];
    // }

    // public Game AddGame(string name, int year)
    // {
    //     var newGame = new Game
    //     {
    //         Name = name,
    //         Year = year,
    //         Status = GameStatus.NotStarted,
    //         Fields = this.CreateGameFields(),
    //     };

    //     this.Games.Add(newGame);

    //     return newGame;
    // }

    // private IEnumerable<GameField> CreateGameFields()
    // {
    //     // return this.FieldsDefinition.Select(fd => new GameField(fd.Name, JsonValue.Create(""))).ToList();
    //     JsonArray.Create()
    // }
}