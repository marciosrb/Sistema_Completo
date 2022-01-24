

using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.DataAccess;
using Cadastro.Domain.DataAccess.EntityFramework;
using Cadastro.Domain.Entity;
using Cadastro.Infrastructure.Repositories;
using Cadastro.Infrastructure.Repositories.EntityFramework;
using Cadastro.Infrastructure.Repositories.EntityFramework.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cadastro.CrossCutting.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {           
         /*   services.Configure<MongoDatabaseSettings>(
            configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<IMongoDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);     */       

            services.AddTransient<IGenericRepository<Usuario, UsuarioContext>, GenericRepository<Usuario, UsuarioContext>>();  
            services.AddTransient<IGenericRepository<UsuarioDto, UsuarioContext>, GenericRepository<UsuarioDto, UsuarioContext>>();  

            services.AddTransient<IUsuarioWriteRepository, UsuarioWriteRepository>();
            services.AddTransient<IUsuarioReadRepository, UsuarioReadRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();             

            return services;
        }
    }
}