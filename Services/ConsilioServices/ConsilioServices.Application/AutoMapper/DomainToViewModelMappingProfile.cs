﻿using AutoMapper;
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
            CreateMap<SystemUser, DataUserViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => $"{source.Name} {source.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email));
            CreateMap<MenuAccess, MenuAccessViewModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(source => source.Name));
            CreateMap<TopicAccess, TopicAccessViewModel>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(source => source.MenuAccesses));
        }
    }
}
