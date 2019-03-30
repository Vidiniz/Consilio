using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace ConsilioServices.Application.Services
{
    public class MenuAccessAppService : IMenuAccessAppService
    {
        private readonly IMenuAccessRepository _menuAccessRepository;

        private readonly IMapper _mapper;

        public MenuAccessAppService(IMenuAccessRepository menuAccessRepository, IMapper mapper)
        {
            _menuAccessRepository = menuAccessRepository;
            _mapper = mapper;
        }        

        public IEnumerable<MenuAccessViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<MenuAccess>, IEnumerable<MenuAccessViewModel>>(_menuAccessRepository.GetAll());
        }
    }
}
