using ConsilioServices.Application.ViewModel;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface ISystemProfileAppService
    {
        void Save(SystemProfileViewModel systemProfileViewModel);

        IEnumerable<SystemProfileViewModel> GetAll(int pageNumber = 1, int recordNumbers = 10);

        IEnumerable<SystemProfileViewModel> GetByName(string name, int pageNumber = 1, int recordNumbers = 10);

        SystemProfileViewModel GetById(int id);

        void Update(SystemProfileViewModel systemProfileViewModel);

        void Remove(int id);
    }
}
