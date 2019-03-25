using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemUserRepository : RepositoryBase<SystemUser>, ISystemUserRepository
    {
        public IEnumerable<SystemUser> GetByName(string name)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Name.Contains(name))
                                              .ToList();
        }
    }
}
