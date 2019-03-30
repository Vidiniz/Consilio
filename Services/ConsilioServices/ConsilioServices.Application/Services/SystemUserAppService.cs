using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.Validations;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Entities;
using ConsilioServices.Domain.Exceptions;
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

        public SystemUserViewModel Login(string user, string password)
        {
            if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
                throw new BusisnessException("Usuário e senha não podem ser nulos");

            if (string.IsNullOrEmpty(user))
                throw new BusisnessException("Usuário não pode ser nulo");

            if (string.IsNullOrEmpty(password))
                throw new BusisnessException("Senha não pode ser nula");

            var encriptyPassword = EncryptData.EncryptPassword(password);

            var login = _systemUserRepository.Login(user, encriptyPassword);

            if (login == null)
                throw new BusisnessException("Usuário ou Senha incorretos!");

            return _mapper.Map<SystemUser, SystemUserViewModel>(login);
        }

        public void Remove(int id)
        {
            var objResult = _systemUserRepository.GetById(id);
            _systemUserRepository.Remove(objResult);
        }

        public void Save(SystemUserViewModel systemUserViewModel)
        {
            if (_systemUserRepository.GetExactEmail(systemUserViewModel.Email) != null)
                throw new BusisnessException("Já existe um usuário cadastrado com este e-mail");

            var passwordPower = UtilValidation.GetPasswordPower(systemUserViewModel.Password);

            if ((int)passwordPower < 3)
                throw new BusisnessException($"A senha digitada não atende os requisitos mínimos - Nível {passwordPower}");

            if (systemUserViewModel.Password != systemUserViewModel.ConfirmPassword)
                throw new BusisnessException($"A senha digitada não é igual a confirmação de senha");

            var model = _mapper.Map<SystemUserViewModel, SystemUser>(systemUserViewModel);
            
            model.Password = EncryptData.EncryptPassword(model.Password);

            _systemUserRepository.Add(model);
        }

        public void Update(SystemUserViewModel systemUserViewModel)
        {
            if (_systemUserRepository.GetExactEmail(systemUserViewModel.Email) != null)
                throw new BusisnessException("Já existe um usuário cadastrado com este e-mail");

            var passwordPower = UtilValidation.GetPasswordPower(systemUserViewModel.Password);

            if ((int)passwordPower < 3)
                throw new BusisnessException($"A senha digitada não atende os requisitos mínimos - Nível {passwordPower}");

            if (systemUserViewModel.Password != systemUserViewModel.ConfirmPassword)
                throw new BusisnessException($"A senha digitada não é igual a confirmação de senha");

            var model = _mapper.Map<SystemUserViewModel, SystemUser>(systemUserViewModel);

            model.Password = EncryptData.EncryptPassword(model.Password);

            _systemUserRepository.Add(model);
        }

    }
}
