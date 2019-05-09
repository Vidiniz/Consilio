using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemProfileRepository : RepositoryBase<SystemProfile>, ISystemProfileRepository
    {
        public override SystemProfile GetById(int id)
        {
            return _dataBase.SystemProfiles
                    .Include(profile => profile.SystemProfileMenuAccesses)
                        .ThenInclude(profileAccess => profileAccess.MenuAccess)

                    .Where(profile => profile.Id.Equals(id))
                    .FirstOrDefault();

            //return (from profile in _dataBase.Set<SystemProfile>()
            //        join profileAccess in _dataBase.Set<SystemProfileMenuAccess>().DefaultIfEmpty() on profile.Id equals profileAccess.SystemProfileId
            //        join menuAccess in _dataBase.Set<MenuAccess>().DefaultIfEmpty() on profileAccess.MenuAccessId equals menuAccess.Id
            //        where profile.Id.Equals(id)
            //        select profile).FirstOrDefault();            
        }

        public IEnumerable<SystemProfile> GetByName(string name)
        {
            return _dataBase.Set<SystemProfile>().Where(p => p.Name.Contains(name))
                                                                   .ToList();
        }

    }
}
