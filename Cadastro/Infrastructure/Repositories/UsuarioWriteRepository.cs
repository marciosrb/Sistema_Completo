using System;
using System.Threading;
using System.Threading.Tasks;
using Cadastro.Domain.DataAccess;
using Cadastro.Domain.DataAccess.EntityFramework;
using Cadastro.Domain.Entity;
using Cadastro.Infrastructure.Repositories.EntityFramework.Context;

namespace Cadastro.Infrastructure.Repositories.EntityFramework
{
    public class UsuarioWriteRepository : IUsuarioWriteRepository
    {
        #region Properties
        private IGenericRepository<Usuario, UsuarioContext> UsuarioRepository { get; }

        #endregion

        #region Constructor
        public UsuarioWriteRepository(
            IGenericRepository<Usuario, UsuarioContext> usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        #endregion

        #region UsuarioWriteRepository implementation

        public async Task<Usuario> Create(Usuario usuario, CancellationToken cancellationToken)
        {      
            await UsuarioRepository.Add(usuario, cancellationToken);
            UsuarioRepository.Commit();
            return usuario;            
        }
        public bool Delete(int usuarioId)
        {
            try
            {               
                var usuario = UsuarioRepository.First(x => x.Id == usuarioId);
                usuario.Ativo = 0;               
                UsuarioRepository.Update(usuario);               
                UsuarioRepository.Commit();
                return true;
            }
            catch (Exception)
            {               
                return false;
            }
        }

        #endregion
    }
}