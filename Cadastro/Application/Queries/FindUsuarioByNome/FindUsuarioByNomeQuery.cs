using System.Linq;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Cadastro.Domain.DataAccess;
using MediatR;

namespace Cadastro.Application.Queries.FindUsuarioByNome
{
    public class FindUsuarioByNomeQuery : IRequestHandler<FindUsuarioByNomeRequest, FindUsuarioByNomeResponse>
    {
      #region Properties

        private IUsuarioRepository UsuarioRepository { get; }

        #endregion

        #region Constructor
        public FindUsuarioByNomeQuery(
            IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        #endregion

        #region IRequestHandler Implementation

        public async Task<FindUsuarioByNomeResponse> Handle(FindUsuarioByNomeRequest request, CancellationToken cancellationToken)
        {
            var response = new FindUsuarioByNomeResponse() { StatusCode = (int)HttpStatusCode.OK };
            var adapter = new FindUsuarioByNomeAdapter();

            try
            {
                var listaUsuarios = UsuarioRepository.GetUsuarioByNome(request.Nome); 

                foreach(var itens in listaUsuarios)
                {
                    if (itens == null)
                        {
                            response.Message = "Usuário não encontrado!";
                            response.StatusCode = (int)HttpStatusCode.NoContent;
                   
                            return await Task.FromResult(response);
                    }
                }

                var usuarioDto = new FindUsuarioByNomeAdapter().Adapt(listaUsuarios);   
               
                response.Message = "Success";
                response.Usuario = usuarioDto;

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var message = $"[FindUsuarioByNome] Unexpected error: {ex.Message}";
                
                response.Message = message;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                return await Task.FromResult(response);
            }
        }

        #endregion
    }
}