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
}