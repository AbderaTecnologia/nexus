using System.Data.Entity.Infrastructure.Interception;
using Nexus.Folha.Api;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra.Data.Repositories


{
public interface IFuncionarioRepository
{
    Task<IEnumerable<Funcionario>?>Get();
    Task<FuncionarioRespository> Get(Guid id);
    Task<bool?> Create(Funcionario funcionario);
    Task<bool?> Update(Funcionario funcionario);
    Task<bool?> Delete(Guid id);

}
    
    
}