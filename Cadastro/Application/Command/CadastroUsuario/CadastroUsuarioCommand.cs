using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Cadastro.Domain.DataAccess;
using MediatR;

namespace Cadastro.Application.Command.CadastroUsuario
{
    public class CadastroUsuarioCommand : IRequestHandler<CadastroUsuarioRequest, CadastroUsuarioResponse>
    {
         #region Properties
    private IUsuarioRepository UsuarioRepository { get ;}

    #endregion

    #region Contructor
    public  CadastroUsuarioCommand(IUsuarioRepository usuarioRepository)
    {
        UsuarioRepository = usuarioRepository;
    }
    #endregion

    #region IRequestHandler Implementation
    public async Task<CadastroUsuarioResponse> Handle(CadastroUsuarioRequest request, CancellationToken cancellationToken)
    {
        var response = new CadastroUsuarioResponse();

        try
        {
            var usuario = new CadastroUsuarioAdapter().Adapt(request.Usuario);
            
            var resultado =  await UsuarioRepository.Create(usuario, cancellationToken);                                 

            response.Message = "Success";
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Usuario = resultado;
            
            return await Task.FromResult(response);
            
        }
        catch (Exception)
            {
                response.Message = "An unexpected error occurred. ";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                return await Task.FromResult(response);
            }
    }
     #endregion
    }
}