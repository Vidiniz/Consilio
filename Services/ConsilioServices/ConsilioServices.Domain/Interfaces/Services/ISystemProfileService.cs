using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Services
{
    public interface ISystemProfileService : IServiceBase<SystemProfile>
    {
        IEnumerable<SystemProfile> GetByName(string name);
    }
}
