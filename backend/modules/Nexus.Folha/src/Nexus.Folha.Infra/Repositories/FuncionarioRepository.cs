using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nexus.Folha.Domain.Entities;
using Nexus.Folha.Infra.Persistence;

namespace Nexus.Folha.Infra.Repositories;

public sealed class FuncionarioRepository(ILogger<FuncionarioRepository> _logger, FolhaDbContext _context) : IFuncionarioRepository
{
    public async Task<IEnumerable<Funcionario>> Get()
    {
        try
        {
            return await _context.Funcionarios.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro ao buscar funcionários");
            return null!;
        }
    }

    public async Task<Funcionario?> Get(Guid id)
    {
        try
        {
            return await _context.Funcionarios.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro ao buscar funcionário");
            return null;
        }
    }

    public async Task<bool?> Create(Funcionario funcionario)
    {
        try
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro ao inserir funcionário");
            return null;
        }
    }

    public async Task<bool?> Update(Funcionario funcionario)
    {
        try
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro ao atualizar funcionário");
            return null;
        }
    }

    public async Task<bool?> Delete(Guid id)
    {
        try
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return false;
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro ao deletar funcionário");
            return null;
        }
    }
}