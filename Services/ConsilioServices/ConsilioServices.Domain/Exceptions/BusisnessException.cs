using System;

namespace ConsilioServices.Domain.Exceptions
{
    public class BusisnessException: Exception
    {
        public BusisnessException()
        {
        }

        public BusisnessException(string message)
            : base(message)
        {
        }

        public BusisnessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
