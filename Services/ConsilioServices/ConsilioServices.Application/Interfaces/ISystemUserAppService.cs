using ConsilioServices.Application.ViewModel.SystemTools;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface ISystemUserAppService
    {
        void Save(SystemUserViewModel systemUserViewModel);

        IEnumerable<SystemUserTableViewModel> GetAll(int pageNumber, int recordNumbers);

        IEnumerable<SystemUserTableViewModel> GetByName(string name, int pageNumber, int recordNumbers);

        SystemUserViewModel GetById(int id);

        void Update(SystemUserViewModel systemUserViewModel);

        void Remove(int id);

        string Login(LoginViewModel dataLogin, char[] config);
    }
}
