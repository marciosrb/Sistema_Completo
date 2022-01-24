using System.Text.Json.Serialization;
using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.Entity;

namespace Cadastro.Application.Command.CadastroUsuario
{
    public class CadastroUsuarioResponse
    {
        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyNameAttribute("usuario")]
        public Usuario Usuario { get; set; }
    }
}