using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Repositories
{
    public interface ISystemUserRepository : IRepositoryBase<SystemUser>
    {
        IEnumerable<SystemUser> GetByName(string name);

        IEnumerable<SystemUser> GetByEmail(string email);

        SystemUser GetExactEmail(string email);

        SystemUser Login(string user, string password);
    }
}
