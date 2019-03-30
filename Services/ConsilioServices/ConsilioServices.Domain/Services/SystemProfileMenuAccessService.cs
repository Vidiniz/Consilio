using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Domain.Interfaces.Services;

namespace ConsilioServices.Domain.Services
{
    public class SystemProfileMenuAccessService: ServiceBase<SystemProfileMenuAccess>, ISystemProfileMenuAccessService
    {
        private readonly ISystemProfileMenuAccessRepository _systemProfileMenuAccessRepository;

        public SystemProfileMenuAccessService(ISystemProfileMenuAccessRepository systemProfileMenuAccessRepository)
            :base(systemProfileMenuAccessRepository)
        {
            _systemProfileMenuAccessRepository = systemProfileMenuAccessRepository;
        }
    }
}
