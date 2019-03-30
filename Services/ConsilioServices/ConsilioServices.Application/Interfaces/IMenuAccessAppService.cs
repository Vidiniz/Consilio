using ConsilioServices.Application.ViewModel.SystemTools;
using System.Collections.Generic;

namespace ConsilioServices.Application.Interfaces
{
    public interface IMenuAccessAppService
    {
        IEnumerable<MenuAccessViewModel> GetAll();
    }
}
