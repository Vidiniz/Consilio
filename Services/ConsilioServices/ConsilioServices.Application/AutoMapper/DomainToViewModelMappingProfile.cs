using AutoMapper;
using ConsilioServices.Application.ViewModel;
using ConsilioServices.Domain.Entities;

namespace ConsilioServices.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<SystemUser, SystemUserViewModel>();
            CreateMap<SystemProfile, SystemProfileViewModel>();
        }
    }
}
