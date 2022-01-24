using System.Text.Json.Serialization;
using Cadastro.Domain.Entity;

namespace Cadastro.Application.DataTransferObject
{
    public class UsuarioDto : Base
    {        
        [JsonPropertyNameAttribute("nome")]
        public string Nome { get; set; }

        [JsonPropertyNameAttribute("endereco")]
        public string Endereco { get; set; }

        [JsonPropertyNameAttribute("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyNameAttribute("estado")]
        public string Estado { get; set; }
        
        [JsonPropertyNameAttribute("cep")]
        public int Cep { get; set; }

        [JsonPropertyNameAttribute("telefone")]
        public int Telefone { get; set; }

        [JsonPropertyNameAttribute("celular")]
        public int Celular { get; set; }

        [JsonPropertyNameAttribute("email")]
        public string Email { get; set; } 

        [JsonIgnore]
        [JsonPropertyNameAttribute("ativo")]
        public int Ativo { get; set; } 

        internal static Usuario ToValueObject(UsuarioDto usuario)
        {
            return new Usuario
            {
                Nome = usuario.Nome,
                Endereco = usuario.Endereco,
                Cidade = usuario.Cidade,
                Estado = usuario.Estado,
                Cep = usuario.Cep,
                Telefone = usuario.Telefone,
                Celular = usuario.Celular,
                Email = usuario.Email,
                Ativo = 1
            };
        }
    }
}