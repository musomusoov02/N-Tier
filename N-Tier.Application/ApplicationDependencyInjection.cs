using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using N_Tier.Application.MappingProfiles;
using N_Tier.Application.Services;
using N_Tier.Application.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {

       



        /////


        
        services.AddScoped<IEmployeeService, EmployeeProfile>();
        services.AddScoped<IStudentService, StudentService>();

        
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    
}
