using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Cadastro.Domain.DataAccess;
using MediatR;

namespace Cadastro.Application.Command.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequestHandler<DeleteUsuarioRequest, DeleteUsuarioResponse>
    {
       #region Properties
    private IUsuarioRepository UsuarioRepository { get ;}

    #endregion

    #region Contructor
    public  DeleteUsuarioCommand(IUsuarioRepository usuarioRepository)
    {
        UsuarioRepository = usuarioRepository;
    }
    #endregion 

    #region IRequestHandler implementation

        public async Task<DeleteUsuarioResponse> Handle(DeleteUsuarioRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteUsuarioResponse();

            try
            {               
                var usuario = UsuarioRepository.GetUsuarioById(request.UsuarioId);

                if (usuario == null)
                {
                    response.Message = "Usuário não encontrado!";
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.UsuarioId = request.UsuarioId;
                    return await Task.FromResult(response);
                }               

                if (UsuarioRepository.Delete(usuario.Id))
                {
                    response.Message = "Success";
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.UsuarioId = usuario.Id;
                    return await Task.FromResult(response);
                }

                response.Message = "Deleting failed.";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                response.Message = "An unexpected error occurred.";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return await Task.FromResult(response);
            }
        }

        #endregion
    }
}