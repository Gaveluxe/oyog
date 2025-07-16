
namespace Backend.Domain.ChallengeAggregate;

// TODO: Replace Type with enum
public class FieldDefinition : ValueObject
{
    public string Name { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        return [this.Name, this.Type];
    }
}
