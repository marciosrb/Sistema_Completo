using System.Threading;
using System.Threading.Tasks;
using Cadastro.Domain.Entity;

namespace Cadastro.Domain.DataAccess
{
    public interface IUsuarioWriteRepository
    {
        Task<Usuario> Create(Usuario usuario, CancellationToken cancellationToken);
    }
}