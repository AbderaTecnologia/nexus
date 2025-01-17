using Microsoft.EntityFrameworkCore;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Application.Common.Interfaces;

public interface IFolhaDbContext
{
    DbSet<Funcionario> Funcionarios { get; }
    DbSet<Rescisao> Rescisao { get; }
}
