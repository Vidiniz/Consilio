using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Services
{
    public class SystemProfileService : ServiceBase<SystemProfile>, ISystemProfileService
    {
        private readonly ISystemProfileRepository _systemProfileRepository;

        public SystemProfileService(ISystemProfileRepository systemProfileRepository) : base(systemProfileRepository)
        {
            this._systemProfileRepository = systemProfileRepository;
        }

        public IEnumerable<SystemProfile> GetAll(int pageNumber, int recordNumbers)
        {
            return _systemProfileRepository.GetAll(pageNumber, recordNumbers);
        }

        public IEnumerable<SystemProfile> GetByName(string name, int pageNumber, int recordNumbers)
        {
            return _systemProfileRepository.GetByName(name, pageNumber, recordNumbers);
        }
    }
}
