using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services.Impl;

public class RoomService : IRoomService
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoomResponseModel>> GetAllAsync()
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

    public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateRoomModel updateDarslarModel)
    {
        var employee = await _roomRepository.GetFirstAsync(tl => tl.Id == id);




        employee.FullName = updateDarslarModel.FullName;

        return new UpdateEmployeeResponseModel
        {
            Id = (await _roomRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var employee = await _roomRepository.GetFirstAsync(tl => tl.Id == id);

        return new BaseResponseModel
        {
            Id = (await _roomRepository.DeleteAsync(employee)).Id
        };
    }
}