using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;
using N_Tier.Application.Services;
using N_Tier.Application.Services.Impl;

namespace N_Tier.API.Controllers;

public class StudentController : ApiController
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<StudentResponseModel>>.Success(await _studentService.GetAllAsync()));
    }

    //[HttpPost("all")]
    //public async Task<IActionResult> GetAll(Options options)
    //{
    //    var result = await _todoListService.GetAllAsync(options);

    //    return Ok(ApiResult<PagedResult<TodoList>>.Success(result));
    //}

    [HttpPost("all")]
    public async Task<IActionResult> GetAll(Options options)
    {
        var result = await _studentService.GetAllDTOAsync(options);

        return Ok(ApiResult<PagedResult<StudentResponseModel>>.Success(result));
    }

    [HttpPost("all/quer")]
    public async Task<IActionResult> GetAllQuery(Options options)
    {
        var result = await _todoListService.GetAllWithIQueryableAsync();

        return Ok(ApiResult<List<TodoList>>.Success(result));
    }

    [HttpPost("all/enum")]
    public ActionResult GetAllEnum(Options options)
    {
        var result = _todoListService.GetAllWithIEnumerable();

        return Ok(ApiResult<List<TodoList>>.Success(result));
    }

    [HttpGet("{id:guid}/todoItems")]
    public async Task<IActionResult> GetAllTodoItemsAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<TodoItemResponseModel>>.Success(
            await _todoItemService.GetAllByListIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateStudentModel createStudentModel)
    {
        return Ok(ApiResult<CreateStudentResponseModel>.Success(
            await _studentService.CreateAsync(createStudentModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel)
    {
        return Ok(ApiResult<UpdateTodoListResponseModel>.Success(
            await _todoListService.UpdateAsync(id, updateTodoListModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _todoListService.DeleteAsync(id)));
    }
}

