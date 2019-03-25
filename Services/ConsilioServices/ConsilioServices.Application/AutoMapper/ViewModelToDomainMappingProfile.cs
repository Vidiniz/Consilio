using AutoMapper;
using ConsilioServices.Application.ViewModel.SystemTools;
using ConsilioServices.Domain.Entities;

namespace ConsilioServices.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SystemUserViewModel, SystemUser>();
            CreateMap<SystemProfileViewModel, SystemProfile>();
        }
    }
}
