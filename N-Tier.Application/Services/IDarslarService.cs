using N_Tier.Application.Models.TodoList;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Employee;

namespace N_Tier.Application.Services;

public interface IDarslarService
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
