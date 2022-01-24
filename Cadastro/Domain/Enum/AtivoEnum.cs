using System.ComponentModel;

namespace CQRS.Domain.Enum
{  
    //não utiliza
    public enum AtivoEnum
    {     
        [Description("Ativo")]
        ATIVO = 0,

        [Description("Inativo")]
        INATIVO = 1
    }
}