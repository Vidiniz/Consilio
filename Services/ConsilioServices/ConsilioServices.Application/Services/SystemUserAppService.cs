using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel;
using ConsilioServices.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace ConsilioServices.Application.Services
{
    public class SystemUserAppService: ISystemUserAppService
    {
        private readonly ISystemUserRepository _systemUserRepository;

        private readonly IMapper _mapper;

        public SystemUserAppService(ISystemUserRepository systemUserRepository, IMapper mapper)
        {
            _systemUserRepository = systemUserRepository;

            _mapper = mapper;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemUserViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<Domain.Entities.SystemUser>, IEnumerable<SystemUserViewModel>>(_systemUserRepository.GetAll());
        }

        public SystemUserViewModel GetById(int id)
        {
            return _mapper.Map<Domain.Entities.SystemUser, SystemUserViewModel>(_systemUserRepository.GetById(id));
        }

        public IEnumerable<SystemUserViewModel> GetByName(string name)
        {
            return _mapper.Map<IEnumerable<Domain.Entities.SystemUser>, IEnumerable<SystemUserViewModel>>(_systemUserRepository.GetByName(name));
        }

        public void Remove(int id)
        {
            var objResult = _systemUserRepository.GetById(id);
            _systemUserRepository.Remove(objResult);
        }

        public void Save(SystemUserViewModel systemUserViewModel)
        {
            _systemUserRepository.Add(_mapper.Map<SystemUserViewModel, Domain.Entities.SystemUser>(systemUserViewModel));
        }

        public void Update(SystemUserViewModel systemUserViewModel)
        {
            _systemUserRepository.Update(_mapper.Map<SystemUserViewModel, Domain.Entities.SystemUser>(systemUserViewModel));
        }
    }
}
