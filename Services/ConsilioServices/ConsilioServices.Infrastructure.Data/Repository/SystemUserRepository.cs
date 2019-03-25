using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemUserRepository : RepositoryBase<SystemUser>, ISystemUserRepository
    {
        public SystemUser GetExactEmail(string email)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Email.Equals(email))
                                                                   .FirstOrDefault();
        }

        public IEnumerable<SystemUser> GetByEmail(string email)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Email.Contains(email))
                                                                   .ToList();
        }

       
        public IEnumerable<SystemUser> GetByName(string name)
        {
            return (from result in _dataBase.Set<SystemUser>()
                    where result.Name.Contains(name)
                    || result.LastName.Contains(name)
                    select result).ToList();
        }
    }
}
