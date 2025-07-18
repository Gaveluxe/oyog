namespace Backend.Api.Common.Dtos;

public class ChallengeResponse
{
    public required Guid Id { get; init; }

    public required string ShortId { get; init; }

    public required int Year { get; init; }
}
