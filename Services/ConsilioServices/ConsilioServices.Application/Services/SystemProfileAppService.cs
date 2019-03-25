using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel;
using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace ConsilioServices.Application.Services
{
    public class SystemProfileAppService: ISystemProfileAppService
    {
        private readonly ISystemProfileRepository _systemProfileRepository;

        private readonly IMapper _mapper;

        public SystemProfileAppService(ISystemProfileRepository systemProfileRepository, IMapper mapper)
        {
            _systemProfileRepository = systemProfileRepository;

            _mapper = mapper;
        }

        public IEnumerable<SystemProfileViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<SystemProfile>, IEnumerable<SystemProfileViewModel>>(_systemProfileRepository.GetAll());
        }

        public SystemProfileViewModel GetById(int id)
        {
            return _mapper.Map<SystemProfile, SystemProfileViewModel>(_systemProfileRepository.GetById(id));
        }

        public IEnumerable<SystemProfileViewModel> GetByName(string name)
        {
            return _mapper.Map<IEnumerable<SystemProfile>, IEnumerable<SystemProfileViewModel>>(_systemProfileRepository.GetByName(name));
        }

        public void Remove(int id)
        {
            var objResult = _systemProfileRepository.GetById(id);

            _systemProfileRepository.Remove(objResult);
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
