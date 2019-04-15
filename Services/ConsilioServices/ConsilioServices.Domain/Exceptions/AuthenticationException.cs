using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Domain.Exceptions
{
    public class AuthenticationException: BusisnessException
    {
        public AuthenticationException()
        {
        }

        public AuthenticationException(string message)
            : base(message)
        {
        }

        public AuthenticationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
