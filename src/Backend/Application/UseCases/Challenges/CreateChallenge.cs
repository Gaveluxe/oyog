
using System.Text.Json;

using Backend.Application.Dto;

namespace Backend.Application.UseCases.Challenges;

public record CreateChallengeCommand(int year, JsonDocument customFields) : ICommand<ChallengeDto>;

public record CreateChallengeHander(IApplicationDbContext DbContext) : ICommandHandler<CreateChallengeCommand, ChallengeDto>
{
    public async Task<ChallengeDto> HandleAsync(CreateChallengeCommand command, CancellationToken cancellationToken = default)
    {
        var challenge = new Challenge()
        {
            Id = Guid.CreateVersion7(),
            Year = command.year,
            CustomFields = command.customFields
        };

        await DbContext.Challenges.AddAsync(challenge, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return ChallengeDto.FromEntity(challenge);
    }
}