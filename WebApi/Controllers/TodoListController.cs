using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController
{
    private readonly TodoListService _todolistService;

    public TodoListController(TodoListService todolistService)
    {
        _todolistService = todolistService;
    }
    
    [HttpGet]
    public async Task<Response<List<GetTodoListDto>>> Get()
    {
        return  await _todolistService.GetTodoLists();
    }
    
    [HttpPost]
    public async Task<Response<AddTodoListDto>> Post(AddTodoListDto todo)
    {
        return await _todolistService.AddTodoLists(todo);
    }
    
    [HttpPut]
    public async Task<Response<AddTodoListDto>> Put(AddTodoListDto todo)
    {
        return await _todolistService.Update(todo);
    }
    
    [HttpDelete]
    public async Task Delete(int id)
    {
        await _todolistService.Delete(id);
    }
}