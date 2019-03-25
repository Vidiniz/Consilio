using ConsilioServices.Application.ViewModel;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface ISystemUserAppService
    {
        void Save(SystemUserViewModel systemUserViewModel);

        IEnumerable<SystemUserViewModel> GetAll(int pageNumber = 1, int recordNumbers = 10);

        IEnumerable<SystemUserViewModel> GetByName(string name, int pageNumber = 1, int recordNumbers = 10);

        SystemUserViewModel GetById(int id);

        void Update(SystemUserViewModel systemUserViewModel);

        void Remove(int id);
    }
}
