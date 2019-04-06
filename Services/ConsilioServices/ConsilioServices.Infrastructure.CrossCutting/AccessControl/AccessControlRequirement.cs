using Microsoft.AspNetCore.Authorization;

namespace ConsilioServices.Infrastructure.CrossCutting.AccessControl
{
    public class AccessControlRequirement : IAuthorizationRequirement
    {
        public string DataAccessRequirement { get; private set; }

        public AccessControlRequirement(string accessRequirement)
        {
            DataAccessRequirement = accessRequirement;
        }
    }
}

