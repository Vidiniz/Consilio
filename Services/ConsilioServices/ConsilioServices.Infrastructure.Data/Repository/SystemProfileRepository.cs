using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemProfileRepository : RepositoryBase<SystemProfile>, ISystemProfileRepository
    {
        public override SystemProfile GetById(int id)
        {
            return (from profile in _dataBase.Set<SystemProfile>()
                    join profileAccess in _dataBase.Set<SystemProfileMenuAccess>() on profile.Id equals profileAccess.SystemProfileId
                    join menuAccess in _dataBase.Set<MenuAccess>() on profileAccess.MenuAccessId equals menuAccess.Id
                    where profile.Id.Equals(id)
                    select profile).FirstOrDefault();
        }

        public IEnumerable<SystemProfile> GetByName(string name)
        {
            return _dataBase.Set<SystemProfile>().Where(p => p.Name.Contains(name))
                                                                   .ToList();
        }
    }
}
