using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ConsilioServices.Infrastructure.CrossCutting.AccessControl
{
    public class AccessSpendPolicy : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider defaultAuthorizationPolicyProvider { get; private set; }

        public AccessSpendPolicy(IOptions<AuthorizationOptions> options)
        {
            defaultAuthorizationPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return defaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            return defaultAuthorizationPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
