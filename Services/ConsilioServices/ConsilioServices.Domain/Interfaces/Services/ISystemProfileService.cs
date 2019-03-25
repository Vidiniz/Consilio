using ConsilioServices.Domain.Entities;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Services
{
    public interface ISystemProfileService : IServiceBase<SystemProfile>
    {
        IEnumerable<SystemProfile> GetByName(string name, int pageNumber, int recordNumbers);

        IEnumerable<SystemProfile> GetAll(int pageNumber, int recordNumbers);
    }
}
