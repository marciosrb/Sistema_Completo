using System.Collections.Generic;
using System.Linq;
using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.DataAccess;
using Cadastro.Domain.DataAccess.EntityFramework;
using Cadastro.Domain.Entity;
using Cadastro.Infrastructure.Repositories.EntityFramework.Context;

namespace Cadastro.Infrastructure.Repositories.EntityFramework
{
    public class UsuarioReadRepository : IUsuarioReadRepository
    {

        #region Properties
        private IGenericRepository<Usuario, UsuarioContext> UsuarioRepository { get; }

        #endregion

        #region Constructor
        public UsuarioReadRepository(
            IGenericRepository<Usuario, UsuarioContext> usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        #endregion

        public List<Usuario> GetUsuarioByNome(string nome)
        {          
            var response = UsuarioRepository.Find(x => x.Nome.Contains(nome) && x.Ativo == 1).ToList();          

            return response;
        }

        public Usuario GetUsuarioById(int usuarioId)
        {
            var response = UsuarioRepository.Find(x => x.Id == usuarioId && x.Ativo == 1);

            return response.FirstOrDefault();
        }
    }
}