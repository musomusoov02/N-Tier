using AutoMapper;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<CreateAdminModel, Admin>();
        CreateMap<UpdateAdminModel, Admin>();
    }
}
