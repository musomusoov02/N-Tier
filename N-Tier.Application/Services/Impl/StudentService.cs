using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services.Impl;

public class StudentService : IStudentService
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository employeeRepository, IMapper mapper)
    {
        _studentRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentResponseModel>> GetAllAsync()
    {

        var employees = await _studentRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

        return _mapper.Map<IEnumerable<StudentResponseModel>>(employees);
    }



    public async Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createDarslarModel)
    {
        var employee = _mapper.Map<Student>(createDarslarModel);

        var addedEmployee = await _studentRepository.AddAsync(employee);

        return new CreateStudentResponseModel
        {
            Id = addedEmployee.Id
        };
    }

    public async Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateDarslarModel)
    {
        var employee = await _studentRepository.GetFirstAsync(tl => tl.Id == id);




        employee.FullName = updateDarslarModel.FullName;

        return new UpdateStudentResponseModel
        {
            Id = (await _studentRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var employee = await _studentRepository.GetFirstAsync(tl => tl.Id == id);

        return new BaseResponseModel
        {
            Id = (await _studentRepository.DeleteAsync(employee)).Id
        };
    }
}