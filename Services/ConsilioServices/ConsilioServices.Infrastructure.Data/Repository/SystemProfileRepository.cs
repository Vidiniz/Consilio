using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class SystemProfileRepository : RepositoryBase<SystemProfile>, ISystemProfileRepository
    {
        public IEnumerable<SystemProfile> GetAll(int pageNumber = 1, int recordNumbers = 10)
        {           
            return _dataBase.Set<SystemProfile>().ToPagedList(pageNumber, recordNumbers)                                                     
                                                     .ToList();
        }

        public IEnumerable<SystemProfile> GetByName(string name, int pageNumber, int recordNumbers)
        {
            return _dataBase.Set<SystemProfile>().Where(p => p.Name.Contains(name))
                                                 .ToPagedList(pageNumber, recordNumbers)
                                                 .ToList();
        }

        public IEnumerable<SystemProfile> GetByName(string name)
        {
            return _dataBase.Set<SystemProfile>().Where(p => p.Name.Contains(name))
                                      //.ToPagedList(pageNumber, recordNumbers)
                                      .ToList();
        }
    }
}
