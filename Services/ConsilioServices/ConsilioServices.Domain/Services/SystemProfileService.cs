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
            _systemProfileRepository = systemProfileRepository;
        }

        public IEnumerable<SystemProfile> GetByName(string name)
        {
            return _systemProfileRepository.GetByName(name);
        }
    }
}
