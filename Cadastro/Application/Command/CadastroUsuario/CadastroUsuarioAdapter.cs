using Cadastro.Domain.Entity;
using Cadastro.Application.DataTransferObject;

namespace Cadastro.Application.Command.CadastroUsuario
{
    public class CadastroUsuarioAdapter
    {
        public Usuario Adapt(UsuarioDto cadastroUsuarioDto)
        {
            return UsuarioDto.ToValueObject(cadastroUsuarioDto);
        }
    }

}