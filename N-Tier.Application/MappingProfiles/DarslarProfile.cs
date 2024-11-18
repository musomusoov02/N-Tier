using AutoMapper;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles;

public class DarslarProfile : Profile
{
    public DarslarProfile()
    {
        CreateMap<CreateDarslarModel, Darslar>();
        CreateMap<UpdateDarslarModel, Darslar>();
    }
}
