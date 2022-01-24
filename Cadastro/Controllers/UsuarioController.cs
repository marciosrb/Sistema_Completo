using Ardalis.GuardClauses;
using Cadastro.Application.Command.CadastroUsuario;
using Cadastro.Application.Queries.FindUsuarioByNome;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Cadastro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Properties

        private IMediator Mediator { get; }

        #endregion

        #region Constructor

        public UsuarioController(
        IMediator mediator
       )
        {
            Guard.Against.Null(mediator, nameof(mediator));

            Mediator = mediator;
        }

        #endregion

        #region Commands
        [HttpPost]
        public async Task<ActionResult> CadastroUsuario(
            [FromBody] CadastroUsuarioRequest request,
            CancellationToken cancellationToken)
        {           
            var response = await Mediator.Send(request, cancellationToken);
            
            return Ok(response);
        }

        #endregion

        #region Gets
        [HttpGet]
        public async Task<ActionResult> FindUsuarioByNome(
            [FromQuery] FindUsuarioByNomeRequest request,
            CancellationToken cancellationToken)
        {           
            var response = await Mediator.Send(request, cancellationToken);
            
            return Ok(response);
        }

        #endregion

        
    }
}