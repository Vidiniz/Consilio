using ConsilioServices.Infrastructure.CrossCutting.AccessContext;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace ConsilioServices.Infrastructure.CrossCutting.AccessControl
{
    public class AccessControlHandlerRequirement : AuthorizationHandler<AccessControlRequirement>
    {       
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessControlRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type.Equals("UserId")))
                return Task.FromResult(0);

            var userId = context.User.Claims.Where(c => c.Type.Equals("UserId")).FirstOrDefault().Value;

            if (string.IsNullOrEmpty(userId))
                return Task.FromResult(0);

            var objectValue = new DataExecuteCommand().GetDataAccess(int.Parse(userId));

            if (objectValue.MenuAccess.Where(r => r.Equals(requirement.DataAccessRequirement)).Count() > 0)
                context.Succeed(requirement);

            return Task.FromResult(0);
        }
    }
}
