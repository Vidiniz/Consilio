using ConsilioServices.Application.ViewModel;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface ISystemUserAppService
    {
        void Save(SystemUserViewModel systemUserViewModel);

        IEnumerable<SystemUserViewModel> GetAll();

        SystemUserViewModel GetById(int id);

        void Update(SystemUserViewModel systemUserViewModel);

        void Remove(int id);

        IEnumerable<SystemUserViewModel> GetByName(string name);
    }
}
