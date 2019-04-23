using ConsilioServices.Application.ViewModel.SystemTools;

namespace ConsilioServices.Application.Interfaces
{
    public interface IAuthenticationAppService
    {
        bool ValidateToken(string token, char[] config);

        DataUserViewModel Login(LoginViewModel dataLogin, char[] config);
    }
}
