using N_Tier.Core.Entities;

namespace N_Tier.Application.Models.Student;

public class UpdateStudentModel
{
    public Person Person { get; set; }
}

public class UpdateStudentResponseModel : BaseResponseModel { }
