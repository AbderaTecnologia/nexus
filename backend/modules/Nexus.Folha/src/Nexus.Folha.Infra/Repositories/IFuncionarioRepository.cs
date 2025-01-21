
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra.Repositories;

public interface IFuncionarioRepository
{
    Task<IEnumerable<Funcionario>?> Get();
    Task<Funcionario?> Get(Guid id);
    Task<bool?> Create(Funcionario funcionario);
    Task<bool?> Update(Funcionario funcionario);
    Task<bool?> Delete(Guid id);
}