using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Services
{
    public interface ISystemUserService : IServiceBase<SystemUser>
    {
        IEnumerable<SystemUser> GetByName(string name);

        IEnumerable<SystemUser> GetByEmail(string email);

        SystemUser GetExactEmail(string email);

        SystemUser Login(string user, string password);
    }
}
