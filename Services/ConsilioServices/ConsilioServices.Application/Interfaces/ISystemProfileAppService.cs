using ConsilioServices.Application.ViewModel.SystemTools;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface ISystemProfileAppService
    {
        void Save(SystemProfileViewModel systemProfileViewModel);

        IEnumerable<SystemProfileTableViewModel> GetAll(int pageNumber, int recordNumbers);

        IEnumerable<SystemProfileTableViewModel> GetByName(string name, int pageNumber, int recordNumbers);

        SystemProfileViewModel GetById(int id);

        void Update(SystemProfileViewModel systemProfileViewModel);

        void Remove(int id);        
    }
}
