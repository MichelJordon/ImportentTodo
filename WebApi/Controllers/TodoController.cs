using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }
    [HttpGet]
    public async Task<Response<List<GetTodoDto>>> Get()
    {
        return  await _todoService.GetTodos();
    }
    [HttpPost("Insert")]
    public async Task<Response<GetTodoDto>> AddTodo([FromForm]AddTodoDto todo)
    {
        return await _todoService.AddTodo(todo);
    }
    [HttpPut("Update")]
    public async Task<GetTodoDto> Update([FromForm]AddTodoDto todo)
    {
        return await _todoService.Update(todo);
    }
}