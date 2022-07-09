using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Validations
{
    /// <summary>
    /// Classe de validação de campos do tipo ID
    /// </summary>
    public class IdValidation
    {
        public static bool IsValid(Guid id)
        {
            // verificando se o id é diferente de null e diferente de vazio
            return (id != null && id != Guid.Empty);
        }
    }
}