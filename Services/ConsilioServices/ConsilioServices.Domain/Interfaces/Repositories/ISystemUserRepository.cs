using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Repositories
{
    public interface ISystemUserRepository : IRepositoryBase<SystemUser>
    {
        IEnumerable<SystemUser> GetByName(string name);

        IEnumerable<SystemUser> GetByName(string name, int pageNumber, int recordNumbers);

        IEnumerable<SystemUser> GetAll(int pageNumber, int recordNumbers);
    }
}
