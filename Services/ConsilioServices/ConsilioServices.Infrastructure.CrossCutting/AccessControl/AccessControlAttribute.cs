using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Infrastructure.CrossCutting.AccessControl
{
    public class AccessControlAttribute: AuthorizeAttribute 
    {

        public AccessControlAttribute(string accessName)
        {
            AccessControlName = accessName;
        }

        public string AccessControlName { get; private set; }
    }
}
