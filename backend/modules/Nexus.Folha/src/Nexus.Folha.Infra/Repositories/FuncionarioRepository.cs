using System.Data;
using DapperExtensions;
using Microsoft.Extensions.Logging;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra.Repositories;

public sealed class FuncionarioRepository(ILogger<FuncionarioRepository> logger, IDbConnection connection) : IFuncionarioRepository
{
    public async Task<IEnumerable<Funcionario>> Get()
    {
        try
        {
            return await connection.GetListAsync<Funcionario>();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Erro ao buscar funcionários");
            return null!;
        }
        
    }

    public async Task<Funcionario?> Get(Guid id)
    {
        try
        {
          return await connection.GetAsync<Funcionario>(id.ToString());  
        }
        catch (Exception e)
        {
            logger.LogError(e, "Erro ao buscar funcionário");
            return null;
        }
    }

    public async Task<bool?> Create(Funcionario Funcionario)
    {
        try
        {
            await connection.InsertAsync(Funcionario);
            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Erro ao inserir funcionário");
            return null;
        }
    }
    
    public async Task<bool?> Update(Funcionario funcionario)
    {
        try
        {
            return await connection.UpdateAsync(funcionario);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Erro ao atualizar funcionário");
            return null;
        }
    }

    public async Task<bool?> Delete(Guid id)
    {
        try
        {
            var Funcionario = new Funcionario
            {
                Id = id
            };
            
            return await connection.DeleteAsync(Funcionario);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Erro ao deletar funcionário");
            return null;
        }
    }
}