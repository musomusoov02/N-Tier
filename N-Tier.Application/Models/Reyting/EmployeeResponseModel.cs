namespace N_Tier.Application.Models.Employee;

public class AdminResponseModel : BaseResponseModel
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    public int Salary { get; set; }
    public string Adress { get; set; }
    public N_Tier.Core.Enums.JobTitle JobTitle { get; set; }
}
