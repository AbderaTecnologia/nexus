using System.Collections;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra.Repositories;

public interface IFuncionarioRepository
{
    Task<IEnumerable<Funcionario>> Get();
}