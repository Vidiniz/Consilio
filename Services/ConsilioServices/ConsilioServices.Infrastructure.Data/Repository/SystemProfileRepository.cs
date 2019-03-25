using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemProfileRepository : RepositoryBase<SystemProfile>, ISystemProfileRepository
    {
        public IEnumerable<SystemProfile> GetByName(string name)
        {
            return _dataBase.Set<SystemProfile>().Where(p => p.Name.Contains(name))
                                                                   .ToList();
        }
    }
}
