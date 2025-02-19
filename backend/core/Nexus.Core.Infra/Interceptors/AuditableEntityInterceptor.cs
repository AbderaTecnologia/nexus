using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Nexus.Core.Application.Models;
using Nexus.Core.Domain.Entities.Base;
using Nexus.Core.Domain.Entities.Interfaces;
using Nexus.Core.Extensions;

namespace Nexus.Core.Infra.Interceptors;

public class AuditableEntityInterceptor(IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    public Guid CompanyId => AuthenticatedUser.FromClaimsPrincipal(_httpContextAccessor.HttpContext.User).CompanyId;

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        var user = AuthenticatedUser.FromClaimsPrincipal(_httpContextAccessor.HttpContext.User);
        SetAuditInfoAdded(user, eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        var user = AuthenticatedUser.FromClaimsPrincipal(_httpContextAccessor.HttpContext.User);
        SetAuditInfoAdded(user, eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    protected virtual void SetCompanyId(DbContext? context)
    {
        context?.ChangeTracker
            .Entries()
            .Select(e => e.Entity)
            .OfType<ICompanyId>()
            .Where(e => e.CompanyId == Guid.Empty)
            .ForEach(e =>
            {
                if (CompanyId == Guid.Empty)
                    throw new InvalidOperationException($"Cannot set an empty CompanyId on {e.GetType()} entity.");

                e.CompanyId = CompanyId;
            });
    }

    protected virtual void SetAuditInfoAdded(AuthenticatedUser user, DbContext? context)
    {
        context?.ChangeTracker
            .Entries<EntityBase>()
            .Where(e => e.State == EntityState.Added)
            .ToList()
            .ForEach(e =>
            {
                e.Entity.CreatedBy = user.UserId;
                e.Entity.CreatedAt = DateTime.Now;
                e.Entity.UpdatedBy = user.UserId;
                e.Entity.UpdatedAt = DateTime.Now;
            });
    }

    protected virtual void SetAuditInfoModified(AuthenticatedUser user, DbContext? context)
    {
        context?.ChangeTracker
            .Entries<EntityBase>()
            .Where(e => e.State == EntityState.Modified)
            .ToList()
            .ForEach(e =>
            {
                e.Entity.UpdatedBy = user.UserId;
                e.Entity.UpdatedAt = DateTime.Now;
            });
    }
}