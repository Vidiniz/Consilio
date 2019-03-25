using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemUserRepository : RepositoryBase<SystemUser>, ISystemUserRepository
    {
        public IEnumerable<SystemUser> GetAll(int pageNumber = 1, int recordNumbers = 10)
        {
            return _dataBase.Set<SystemUser>().ToPagedList(pageNumber, recordNumbers)
                                              .ToList();
        }

        public IEnumerable<SystemUser> GetByName(string name, int pageNumber, int recordNumbers)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Name.Contains(name))
                                              .ToPagedList(pageNumber, recordNumbers)
                                              .ToList();
        }

        public IEnumerable<SystemUser> GetByName(string name)
        {
            return _dataBase.Set<SystemUser>().Where(su => su.Name.Contains(name))
                                  //.ToPagedList(1, 10)
                                  .ToList();
        }
    }
}
