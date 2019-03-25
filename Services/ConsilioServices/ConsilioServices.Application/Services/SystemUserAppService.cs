using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using X.PagedList;

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

        public IEnumerable<SystemUserTableViewModel> GetAll(int pageNumber, int recordNumbers)
        { 
            return _mapper.Map<IEnumerable<SystemUser>, IEnumerable<SystemUserTableViewModel>>(_systemUserRepository.GetAll(pageNumber, recordNumbers));
        }

        public SystemUserViewModel GetById(int id)
        {
            return _mapper.Map<SystemUser, SystemUserViewModel>(_systemUserRepository.GetById(id));
        }

        public IEnumerable<SystemUserTableViewModel> GetByName(string name, int pageNumber, int recordNumbers)
        {
            return _mapper.Map<IEnumerable<SystemUser>, IEnumerable<SystemUserTableViewModel>>(_systemUserRepository.GetByName(name).ToPagedList(pageNumber, recordNumbers));
        }

        public void Remove(int id)
        {
            var objResult = _systemUserRepository.GetById(id);
            _systemUserRepository.Remove(objResult);
        }

        public void Save(SystemUserViewModel systemUserViewModel)
        {
            _systemUserRepository.Add(_mapper.Map<SystemUserViewModel, SystemUser>(systemUserViewModel));
        }

        public void Update(SystemUserViewModel systemUserViewModel)
        {
            _systemUserRepository.Update(_mapper.Map<SystemUserViewModel, SystemUser>(systemUserViewModel));
        }
    }
}
