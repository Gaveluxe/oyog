namespace Backend.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    // TODO: Autoupdate this column
    public DateTimeOffset CreatedAt { get; set; }

    // TODO: Autoupdate this column
    public DateTimeOffset UpdatedAt { get; set; }
}