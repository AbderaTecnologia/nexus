using System.Data;
using DapperExtensions;
using Microsoft.Extensions.Logging;
using Nexus.Folha.Domain.Entities;


namespace Nexus.Folha.Infra.Data.Repositories;

public class FuncionarioRespository(ILogger<Funcionario> logger, IDbConnection connection) 
{
    public async Task<IEnumerable<Funcionario>?> Get()
    {
        try
        {
            return await connection.GetListAsync<Funcionario>();

        }
        catch (Exception e)
        {
            logger.LogError(e,"Erro ao obter Funcionario");
            return null;
        }
    }

    public async Task<Funcionario?> Get(Guid id)
    {
        try
        {
            return await connection.GetAsync<Funcionario?>(id.ToString());

        }
        catch (Exception e)
        {
            logger.LogError(e,"Erro ao obter Funcionario");
            return null;
        }
    }

    public async Task<bool?> Create (Funcionario Funcionario)
    {
        try
        {
            await connection.InsertAsync(Funcionario);
            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e,"Erro ao criar Funcionario");
            return null;
        }
    }


    public async Task<bool?> Update(Funcionario Funcionario)
    {
        try
        {
            return await connection.UpdateAsync(Funcionario);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Erro ao atualizar Funcionario");
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
            logger.LogError(e, "Erro em Deletar Funcionario ");
            return null;
        }
    }

}