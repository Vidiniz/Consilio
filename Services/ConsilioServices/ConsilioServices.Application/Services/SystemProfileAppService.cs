using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Exceptions;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Application.Services
{
    public class SystemProfileAppService: ISystemProfileAppService
    {
        private readonly ISystemProfileRepository _systemProfileRepository;

        private readonly ISystemUserRepository _systemUserRepository;

        private readonly IMapper _mapper;

        public SystemProfileAppService(ISystemProfileRepository systemProfileRepository, ISystemUserRepository systemUserRepository, IMapper mapper)
        {
            _systemProfileRepository = systemProfileRepository;

            _systemUserRepository = systemUserRepository;

            _mapper = mapper;
        }

        public IEnumerable<SystemProfileTableViewModel> GetAll(int pageNumber, int recordNumbers)
        {
            return _mapper.Map<IEnumerable<SystemProfile>, IEnumerable<SystemProfileTableViewModel>>(_systemProfileRepository.GetAll(pageNumber, recordNumbers));
        }

        public SystemProfileViewModel GetById(int id)
        {
            return _mapper.Map<SystemProfile, SystemProfileViewModel>(_systemProfileRepository.GetById(id));
        }

        public IEnumerable<SystemProfileTableViewModel> GetByName(string name, int pageNumber, int recordNumbers)
        {
            return _mapper.Map<IEnumerable<SystemProfile>, IEnumerable<SystemProfileTableViewModel>>(_systemProfileRepository.GetByName(name));
        }

        public void Remove(int id)
        {
            var profile = _systemProfileRepository.GetById(id);

            var users = _systemUserRepository.GetUsersByProfile(profile.Id).ToList();

            if (users.Count > 0)
                throw new BusisnessException("Não é possível remover um perfil associado a um Usuário");

            _systemProfileRepository.Remove(profile);
        }

        public void Save(SystemProfileViewModel systemProfileViewModel)
        {
            _systemProfileRepository.Add(_mapper.Map<SystemProfileViewModel, SystemProfile>(systemProfileViewModel));
        }

        public void Update(SystemProfileViewModel systemProfileViewModel)
        {
            _systemProfileRepository.Update(_mapper.Map<SystemProfileViewModel, SystemProfile>(systemProfileViewModel));
        }
    }
}
