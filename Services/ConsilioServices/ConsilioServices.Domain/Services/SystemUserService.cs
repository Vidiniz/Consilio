using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ConsilioServices.Domain.Services
{
    public class SystemUserService : ServiceBase<SystemUser>, ISystemUserService
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserService(ISystemUserRepository systemUserRepository) : base(systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public IEnumerable<SystemUser> GetAll(int pageNumber, int recordNumbers)
        {
            return _systemUserRepository.GetAll(pageNumber, recordNumbers);
        }

        public IEnumerable<SystemUser> GetByName(string name, int pageNumber, int recordNumbers)
        {
            return _systemUserRepository.GetByName(name, pageNumber, recordNumbers);
        }
    }
}
