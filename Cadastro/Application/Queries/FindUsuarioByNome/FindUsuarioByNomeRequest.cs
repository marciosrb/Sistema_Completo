using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace Cadastro.Application.Queries.FindUsuarioByNome
{
    public class FindUsuarioByNomeRequest : IRequest<FindUsuarioByNomeResponse>
    {
        [Required(ErrorMessage = "The {0} cannot be null.")]
        [JsonPropertyNameAttribute("nome")]
        public string Nome { get; set; } 
    }
}