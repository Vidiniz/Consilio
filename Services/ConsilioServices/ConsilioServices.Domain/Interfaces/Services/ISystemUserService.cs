using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Services
{
    public interface ISystemUserService : IServiceBase<SystemUser>
    {
        IEnumerable<SystemUser> GetByName(string name);
    }
}
