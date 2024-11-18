using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services;

public interface IEmployeeService
{
    Task<CreateEmployeeResponseModel> CreateAsync(CreateStudentModel createTodoListModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<AdminResponseModel>> GetAllAsync();
    Task<List<Employee>> GetAllWithIQueryableAsync();
    List<Employee> GetAllWithIEnumerable();
    Task<PagedResult<Employee>> GetAllAsync(Options options);
    Task<PagedResult<AdminResponseModel>> GetAllDTOAsync(Options options);
    Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateAdminModel updateEmployeeModel);
}
