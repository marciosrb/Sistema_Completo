using System.Text.Json.Serialization;

namespace Cadastro.Application.Command.DeleteUsuario
{
    public class DeleteUsuarioResponse
    {
        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyNameAttribute("usuarioId")]
        public int UsuarioId {get;set;}
    }
}