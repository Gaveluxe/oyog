using Backend.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Api.Data.Helpers;

internal class AuditColumnInterceptor(TimeProvider time) : SaveChangesInterceptor
{
    private readonly TimeProvider time = time;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        this.UpdateAuditColumns(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        this.UpdateAuditColumns(eventData);
        return base.SavingChanges(eventData, result);
    }

    private void UpdateAuditColumns(DbContextEventData eventData)
    {
        foreach (var entry in eventData.Context!.ChangeTracker.Entries())
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    baseEntity.CreatedAt = this.time.GetUtcNow();
                    baseEntity.UpdatedAt = this.time.GetUtcNow();
                }
                else if (entry.State == EntityState.Modified)
                {
                    baseEntity.UpdatedAt = this.time.GetUtcNow();
                }
            }
        }
    }
}
