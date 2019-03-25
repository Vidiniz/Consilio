using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Repositories
{
    public interface ISystemProfileRepository: IRepositoryBase<SystemProfile>
    {
        IEnumerable<SystemProfile> GetByName(string name);
    }
}
