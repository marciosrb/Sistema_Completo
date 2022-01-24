using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.Entity;

namespace Cadastro.Domain.DataAccess
{
    public interface IUsuarioReadRepository
    {
        List<Usuario> GetUsuarioByNome(string nome);
    }
}