using System.Collections.Generic;
using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.Entity;

namespace Cadastro.Application.Queries.FindUsuarioByNome
{
    public class FindUsuarioByNomeAdapter
    {
        public List<Usuario> Adapt(List<Usuario> usuarios)
        {
            var usuariosDto = new List<Usuario>();
            usuarios.ForEach(usuario =>
            {
                var usuarioDto = new Usuario()
                {
                    Id = usuario.Id,               
                    Nome = usuario.Nome,
                    Endereco = usuario.Endereco,
                    Cidade = usuario.Cidade,
                    Estado = usuario.Estado,
                    Cep = usuario.Cep,
                    Telefone = usuario.Telefone,
                    Celular = usuario.Celular,
                    Email = usuario.Email
                };
                usuariosDto.Add(usuarioDto); 
            }); 
            return usuariosDto;
        }
    }
}