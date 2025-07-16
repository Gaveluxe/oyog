using Ardalis.SmartEnum;

namespace Backend.Domain.ChallengeAggregate;

public class GameStatus : SmartEnum<GameStatus>
{
    public static readonly GameStatus NotStarted = new("Pas commencé", 1);
    public static readonly GameStatus InProgress = new("En cours", 2);
    public static readonly GameStatus Abandoned = new("Abandonné", 3);
    public static readonly GameStatus Finished = new("Terminé", 4);

    private GameStatus(string name, int value) : base(name, value)
    { }

    protected GameStatus() : base("", 0)
    {
        // Parameterless constructor to keep EF happy
    }
}
