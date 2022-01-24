using System.Diagnostics.CodeAnalysis;
using Cadastro.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.Repositories.EntityFramework.Mappings
{
    [ExcludeFromCodeCoverage]
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.Property(c => c.Id).HasColumnName("ID").HasColumnType("int");

            builder.Property(c => c.Nome).HasColumnName("NOME").HasColumnType("string").IsRequired(true);

            builder.Property(c => c.Endereco).HasColumnName("ENDERECO").HasColumnType("string").IsRequired(true);

            builder.Property(c => c.Cidade).HasColumnName("CIDADE").HasColumnType("string").IsRequired(true);

            builder.Property(c => c.Estado).HasColumnName("ESTADO").HasColumnType("string").IsRequired(true);

            builder.Property(c => c.Cep).HasColumnName("CEP").HasColumnType("int").IsRequired(true);

            builder.Property(c => c.Telefone).HasColumnName("TELEFONE").HasColumnType("int").IsRequired(true);

            builder.Property(c => c.Celular).HasColumnName("CELULAR").HasColumnType("int").IsRequired(true);

            builder.Property(c => c.Email).HasColumnName("EMAIL").HasColumnType("int").IsRequired(true);

            
          
        }
    }
}