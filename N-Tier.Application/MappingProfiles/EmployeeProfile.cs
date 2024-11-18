using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeModel, Employee>();
        CreateMap<UpdateEmployeeModel, Employee>();
    }
}
