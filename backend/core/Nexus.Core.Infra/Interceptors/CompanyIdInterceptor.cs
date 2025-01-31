using Microsoft.EntityFrameworkCore.Diagnostics;
using Nexus.Core.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Nexus.Auth.Models;

namespace Nexus.Core.Infra.Interceptors;

public class CompanyIdInterceptor(IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        var context = eventData.Context;
        if (context != null)
        {
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User != null)
            {
                var user = AuthenticatedUser.FromClaimsPrincipal(_httpContextAccessor.HttpContext.User);
                foreach (var entry in context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
                {
                    if (entry.Entity is ICompanyId companyEntity)
                    {
                        companyEntity.CompanyId = user.CompanyId;
                    }
                }
            }
        }
        return base.SavedChanges(eventData, result);
    }
}