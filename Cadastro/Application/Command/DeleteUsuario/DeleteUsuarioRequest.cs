using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace Cadastro.Application.Command.DeleteUsuario
{
    public class DeleteUsuarioRequest : IRequest<DeleteUsuarioResponse>
    {
        [Required(ErrorMessage = "The {0} cannot be null.")]
        [JsonPropertyNameAttribute("usuarioId")]
        public int UsuarioId { get; set; }
    }
}