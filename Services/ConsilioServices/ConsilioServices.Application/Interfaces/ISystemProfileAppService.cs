using ConsilioServices.Application.ViewModel;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface ISystemProfileAppService
    {
        void Save(SystemProfileViewModel systemProfileViewModel);

        IEnumerable<SystemProfileViewModel> GetAll();

        SystemProfileViewModel GetById(int id);

        void Update(SystemProfileViewModel systemProfileViewModel);

        void Remove(int id);

        IEnumerable<SystemProfileViewModel> GetByName(string name);
    }
}
