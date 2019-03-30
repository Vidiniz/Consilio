using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Domain.Interfaces.Services;

namespace ConsilioServices.Domain.Services
{
    public class MenuAccessService : ServiceBase<MenuAccess>, IMenuAccessService
    {
        private readonly IMenuAccessRepository _menuAccessRepository;

        public MenuAccessService(IMenuAccessRepository menuAccessRepository): base(menuAccessRepository)
        {
            _menuAccessRepository = menuAccessRepository;
        }
    }
}
