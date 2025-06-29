namespace Backend.Application.UseCases.Challenges;

public record AddGameToChallengeCommand(Guid ChallengeId, string Name, int Year) : ICommand<GameDto>;

public class AddGameToChallengeHandler(IApplicationDbContext context) : ICommandHandler<AddGameToChallengeCommand, GameDto>
{
    public async Task<GameDto> HandleAsync(AddGameToChallengeCommand command, CancellationToken cancellationToken = default)
    {
        var challenge = await context.Challenges.FindAsync(command.ChallengeId)
            ?? throw new NullReferenceException("Challenge not found");
            
        var newGame = challenge.AddGame(command.Name, command.Year);

        await context.SaveChangesAsync(cancellationToken);

        return GameDto.FromGame(newGame);
    }
}