using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Services.Impl;

public class DarslarService : IDarslarService
{
    private readonly IMapper _mapper;
    private readonly IDarslarRepository _darslarRepository;

    public DarslarService(IDarslarRepository darslarRepository, IMapper mapper)
    {
        _darslarRepository = darslarRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DarslarResponseModel>> GetAllAsync()
    {

        var employees = await _darslarRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

        return _mapper.Map<IEnumerable<DarslarResponseModel>>(employees);
    }

    #region IQueryable vs IEnumurable
    //public async Task<List<Employee>> GetAllWithIQueryableAsync()
    //{
    //    IQueryable<Employee> query = _employeeRepository.GetAll();
    //    query = query.OrderByDescending(a => a.FullName); //order
    //    query = query.Take(1);
    //    int count = query.Count();
    //    var result = query.ToList();

    //    return result;
    //}

    //public List<TodoList> GetAllWithIEnumerable()
    //{
    //    var query = _employeeRepository.GetAllAsEnumurable(); //select * from ;
    //    query = query.OrderByDescending(a => a.Title);
    //    query = query.Take(count: 1); //limit-1
    //    int count = query.Count(); //query to db
    //    var result = query.ToList();

    //    return result;
    //}
    #endregion

    public async Task<CreateDarslarResponseModel> CreateAsync(CreateDarslarModel createDarslarModel)
    {
        var employee = _mapper.Map<Darslar>(createDarslarModel);

        var addedEmployee = await _darslarRepository.AddAsync(employee);

        return new CreateDarslarResponseModel
        {
            Id = addedEmployee.Id
        };
    }

    public async Task<UpdateDarslarResponseModel> UpdateAsync(Guid id, UpdateDarslarModel updateDarslarModel)
    {
        var employee = await _darslarRepository.GetFirstAsync(tl => tl.Id == id);




        employee.FullName = updateDarslarModel.FullName;

        return new UpdateDarslarResponseModel
        {
            Id = (await _darslarRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var employee = await _darslarRepository.GetFirstAsync(tl => tl.Id == id);

        return new BaseResponseModel
        {
            Id = (await _darslarRepository.DeleteAsync(employee)).Id
        };
    }
}
