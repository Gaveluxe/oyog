using System.Text.Json;

namespace Backend.Application.Dto;

public class GameDto
{
    public required string Name { get; init; }

    public required int Year { get; init; }

    public required string Status { get; init; }

    public JsonDocument Fields { get; init; } = JsonDocument.Parse("{}");

    public static GameDto FromGame(Game game)
    {
        return new()
        {
            Name = game.Name,
            Status = game.Status.Name,
            Year = game.Year,
        };
    }
}
