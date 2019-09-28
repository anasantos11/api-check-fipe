using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.Exceptions
{
    public class UnexpectedServiceResponseException : Exception
    {
        public UnexpectedServiceResponseException(Exception exception) : base("Não foi possível obter a resposta do servidor nesse momento. Tente novamente mais tarde.", exception)
        {

        }
    }
}
