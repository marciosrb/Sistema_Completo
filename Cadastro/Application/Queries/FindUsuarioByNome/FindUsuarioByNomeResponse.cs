using System.Collections.Generic;
using System.Text.Json.Serialization;
using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.Entity;

namespace Cadastro.Application.Queries.FindUsuarioByNome
{
    public class FindUsuarioByNomeResponse
    {
        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyNameAttribute("usuario")]
        public List<Usuario> Usuario{ get; set; }
    }
}