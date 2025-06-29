using Backend.Application.Dto;
using Backend.Application.UseCases.Challenges;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Endpoints;

public static class Challenges
{
    public static IEndpointRouteBuilder MapChallenges(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/challenges");

        group.MapPost("", CreateChallenge);
        group.MapPost("{challengeId:guid}/games", AddGame);

        return builder;
    }

    private static async Task<ChallengeDto> CreateChallenge(CreateChallengeCommand command, [FromServices] IMediator mediator)
    {
        return await mediator.SendCommandAsync<CreateChallengeCommand, ChallengeDto>(command);
    }

    private static async Task<GameDto> AddGame([FromRoute] Guid challengeId, [FromBody] AddGameRequest request, [FromServices] IMediator mediator)
    {
        var command = new AddGameToChallengeCommand(challengeId, request.Name, request.Year);
        return await mediator.SendCommandAsync<AddGameToChallengeCommand, GameDto>(command);
    }

    private record AddGameRequest([FromBody] string Name, [FromBody] int Year);
}
