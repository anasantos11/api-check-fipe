using System;

namespace CheckFipe.Domain.Exceptions
{
    public class UnexpectedServiceResponseException : Exception
    {
        public UnexpectedServiceResponseException(Exception exception) : base("Não foi possível obter a resposta do servidor nesse momento. Tente novamente mais tarde.", exception)
        {

        }
    }
}
