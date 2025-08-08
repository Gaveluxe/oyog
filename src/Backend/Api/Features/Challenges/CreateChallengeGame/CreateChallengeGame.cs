using Backend.Api.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Features.Challenges.CreateChallengeGame;

public class CreateChallengeGame : Endpoint<CreateChallengeGameRequest, GameResponse, GameResponse.Mapper>
{
    public required AppDbContext Context { get; set; }

    public override void Configure()
    {
        Post("/api/challenges/{challengeId}/games");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateChallengeGameRequest req, CancellationToken ct)
    {
        var challenge = await this.Context.Challenges.FindAsync((Guid)req.ChallengeId);
        if (challenge == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        var game = challenge.AddGame(req.Year);
        await this.Context.SaveChangesAsync(ct);

        Response = Map.FromEntity(game);
    }
}
