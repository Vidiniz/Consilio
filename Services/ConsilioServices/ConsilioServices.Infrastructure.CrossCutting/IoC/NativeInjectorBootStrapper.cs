﻿using AutoMapper;
using ConsilioServices.Application.Interfaces;
using ConsilioServices.Application.Services;
using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Domain.Interfaces.Services;
using ConsilioServices.Domain.Services;
using ConsilioServices.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ConsilioServices.Infrastructure.CrossCutting.IoC
{   
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            var mappingConfig = Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<ISystemProfileRepository, SystemProfileRepository>();
            services.AddScoped<ISystemUserService, SystemUserService>();
            services.AddScoped<ISystemProfileService, SystemProfileService>();
            services.AddScoped<ISystemProfileAppService, SystemProfileAppService>();
            services.AddScoped<ISystemUserAppService, SystemUserAppService>();
        }
    }
}