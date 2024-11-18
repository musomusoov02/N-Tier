using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<CreateRoomModel, Room>();
        CreateMap<UpdateRoomModel, Room>();
    }
}
