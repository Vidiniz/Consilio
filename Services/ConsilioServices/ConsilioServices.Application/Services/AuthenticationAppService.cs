using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.Validations;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Exceptions;
using ConsilioServices.Domain.Interfaces.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ConsilioServices.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public AuthenticationAppService(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public string Login(LoginViewModel dataLogin, char[] config)
        {
            if (dataLogin == null)
                throw new Exception("Dados Inválidos");

            if (string.IsNullOrEmpty(dataLogin.User) && string.IsNullOrEmpty(dataLogin.Password))
                throw new AuthenticationException("Usuário e senha não podem ser nulos");

            if (string.IsNullOrEmpty(dataLogin.User))
                throw new AuthenticationException("Usuário não pode ser nulo");

            if (string.IsNullOrEmpty(dataLogin.Password))
                throw new AuthenticationException("Senha não pode ser nula");

            var encriptyPassword = EncryptData.EncryptPassword(dataLogin.Password);

            var login = _systemUserRepository.Login(dataLogin.User, encriptyPassword);

            if (login == null)
                throw new AuthenticationException("Usuário ou Senha incorreto(s)!");

            return new GenerationCredentials().GetCrendentials(login, config);
        }

        public bool ValidateToken(string token, char[] config)
        {
            try
            {
                if (_systemUserRepository.GetByEmail(new GenerationCredentials().ValidateCredentials(token, config)) != null)
                    return true;
            }
            catch (SecurityTokenEncryptionKeyNotFoundException ex)
            {
                throw new BusisnessException($"Token inválido - Erro: Falha ao ler Token, por favor contate o administrador do sistema");
            }
            catch (SecurityTokenDecryptionFailedException ex)
            {
                throw new BusisnessException($"Token inválido - Erro: Não foi possível ler o token fornecido");
            }
            catch(SecurityTokenExpiredException ex)
            {
                throw new BusisnessException($"Token inválido - Erro: Token expirado");
            }
            catch(SecurityTokenException ex)
            {
                throw new BusisnessException($"Token inválido - Erro: {ex.Message}");
            }
            catch (Exception ex)
            {                
                throw new Exception($"Erro não catalogado - Original Messager: {ex.Message}");
            }            

            return false;
        }
    }
}
