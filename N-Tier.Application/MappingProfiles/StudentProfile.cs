using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentModel, Student>();
        CreateMap<UpdateStudentModel, Student>();
    }
}
