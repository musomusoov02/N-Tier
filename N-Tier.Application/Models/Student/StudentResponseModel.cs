using N_Tier.Core.Entities;

namespace N_Tier.Application.Models.Student;

public class StudentResponseModel : BaseResponseModel
{
    public Person Person { get; set; }
}
