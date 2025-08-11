using Backend.Api.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Features.Challenges.UpdateChallengeGame;

public sealed class UpdateChallengeGame : Endpoint<UpdateChallengeGameRequest, GameResponse, GameResponse.Mapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Put("/api/challenges/{challengeId}/games/{gameId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateChallengeGameRequest req, CancellationToken ct)
    {
        var challenge = await this.Context.Challenges
            .Include(c => c.Games)
            .SingleOrDefaultAsync(c => c.Games.Any(g => g.ShortId == req.GameId.ToString()));

        if (challenge == null) {
            await Send.NotFoundAsync();
            return;
        }

        var game = challenge.UpdateGame(req.GameId, req.Name, req.Year, req.Status);
        await this.Context.SaveChangesAsync();

        if (game != null)
        {
            Response = Map.FromEntity(game);
        }
    }
}
