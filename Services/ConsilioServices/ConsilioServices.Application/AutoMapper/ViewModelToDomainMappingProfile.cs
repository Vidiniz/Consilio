using AutoMapper;
using ConsilioServices.Application.ViewModel;
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
