using Microsoft.EntityFrameworkCore;
using Nexus.Auth.Domain.Entities;

namespace Nexus.Auth.Infra.Persistence;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}