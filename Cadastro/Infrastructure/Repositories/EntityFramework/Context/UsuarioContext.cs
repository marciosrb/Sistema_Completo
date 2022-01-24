using System.Reflection;
using Cadastro.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infrastructure.Repositories.EntityFramework.Context
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; } 

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}