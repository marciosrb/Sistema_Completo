using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Cadastro.Application.DataTransferObject;
using MediatR;

namespace Cadastro.Application.Command.CadastroUsuario
{
    public class CadastroUsuarioRequest : IRequest<CadastroUsuarioResponse>
    {
        [Required(ErrorMessage = "The {0} cannot be null.")]
        [JsonPropertyNameAttribute("usuario")]
        public UsuarioDto Usuario { get; set; }
    }
}