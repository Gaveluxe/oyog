using System.Text.Json.Nodes;

namespace Backend.Domain.ChallengeAggregate;

public class Game : BaseEntity
{
    public Guid ChallengeId { get; set; }

    public required string Name { get; set; }

    public required int Year { get; set; }

    public required GameStatus Status { get; set; }

    public JsonObject Fields { get; set; } = [];
}