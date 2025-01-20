using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra.Data.Repositories;


    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>?> Get();  
    }
    

   