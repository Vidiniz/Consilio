using AutoMapper;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Entities;

namespace ConsilioServices.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<SystemUser, SystemUserViewModel>();
            CreateMap<SystemUser, SystemUserTableViewModel>();
            CreateMap<SystemProfile, SystemProfileViewModel>();
            CreateMap<SystemProfile, SystemProfileTableViewModel>();
        }
    }
}
