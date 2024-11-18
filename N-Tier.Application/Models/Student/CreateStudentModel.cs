using N_Tier.Core.Entities;

namespace N_Tier.Application.Models.Student;

public class CreateStudentModel
{
    public Person Person { get; set; }
}

public class CreateStudentResponseModel : BaseResponseModel { }
