using Nexus.Core.Domain.Entities.Interfaces;

namespace Nexus.Core.Domain.Entities.Base
{
    public abstract class EntityCompanyBase : EntitySoftDeletedBase, ICompanyId
    {
        public Guid CompanyId { get; set; }
    }
}