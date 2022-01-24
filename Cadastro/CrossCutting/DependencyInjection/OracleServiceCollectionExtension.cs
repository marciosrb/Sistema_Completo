using System.Diagnostics.CodeAnalysis;
using Cadastro.Infrastructure.Repositories.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Cadastro.CrossCutting.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class OracleServiceCollectionExtensions
    {
        public static IServiceCollection AddOracle(this IServiceCollection services, IConfiguration configuration)
        {
            var ora_conn = "User Id=marcio;Password=123456;Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = ORCLCDB.localdomain)))";
            IServiceCollection serviceCollection = services.AddDbContext<UsuarioContext>(options => options.UseOracle(ora_conn));
            return services;
        }
    }
}