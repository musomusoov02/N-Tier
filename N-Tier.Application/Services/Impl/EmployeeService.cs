using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _darslarRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
    {

        var employees = await _employeeRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

        return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
    }



    public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createDarslarModel)
    {
        var employee = _mapper.Map<Employee>(createDarslarModel);

        var addedEmployee = await _employeeRepository.AddAsync(employee);

        return new CreateEmployeeResponseModel
        {
            Id = addedEmployee.Id
        };
    }

    public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateDarslarModel)
    {
        var employee = await _employeeRepository.GetFirstAsync(tl => tl.Id == id);




        employee.FullName = updateDarslarModel.FullName;

        return new UpdateEmployeeResponseModel
        {
            Id = (await _employeeRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var employee = await _employeeRepository.GetFirstAsync(tl => tl.Id == id);

        return new BaseResponseModel
        {
            Id = (await _employeeRepository.DeleteAsync(employee)).Id
        };
    }
}