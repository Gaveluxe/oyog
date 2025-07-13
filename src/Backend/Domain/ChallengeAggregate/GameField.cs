
using System.Text.Json.Nodes;

namespace Backend.Domain.ChallengeAggregate;

public class GameField : ValueObject
{
    public string Name { get; init; }

    public JsonValue Value { get; init; }

    public GameField(string name, JsonValue value)
    {
        this.Name = "_" + name;
        this.Value = JsonValue.Create("");
    }

    protected GameField()
    {
        // Parameterless constructor to keep EF happy
        this.Name = "";
        this.Value = JsonValue.Create("");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        return [this.Name];
    }
}