using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListImageController
{
    private readonly TodoListImagesService _todolistimageService;

    public TodoListImageController(TodoListImagesService todolistService)
    {
        _todolistimageService = todolistService;
    }
    
    [HttpGet]
    public async Task<Response<List<GetTodoListImageDto>>> Get()
    {
        return  await _todolistimageService.GetTodoImageLists();
    }
    
    [HttpPost]
    public async Task<Response<AddTodoListImageDto>> Post(AddTodoListImageDto todo)
    {
        return await _todolistimageService.AddTodoLists(todo);
    }
    
    [HttpPut]
    public async Task<Response<AddTodoListImageDto>> Put(AddTodoListImageDto todo)
    {
        return await _todolistimageService.Update(todo);
    }
    
    [HttpDelete]
    public async Task Delete(int id)
    {
        await _todolistimageService.Delete(id);
    }
}