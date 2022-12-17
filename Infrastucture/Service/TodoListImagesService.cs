using Domain.Entities;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoListImagesService
{
    private readonly DataContext _context;

    public TodoListImagesService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Response<List<GetTodoListImageDto>>> GetTodoImageLists()
    {
       var todos = await _context.TodoListImages.ToListAsync();
        var list = new List<GetTodoListImageDto>();
        foreach (var t in todos)
        {
            var todo = new GetTodoListImageDto()
            {
                Id = t.Id,
                Value = t.Value,
                TodoListId = t.TodoListId
            };
            list.Add(todo);
        }
       return new Response<List<GetTodoListImageDto>>(list);
    }

    public async Task<Response<AddTodoListImageDto>> AddTodoLists(AddTodoListImageDto todo)
    {
            var newTodo = new TodoListImage()
            {
                Value = todo.Value,
                TodoListId = todo.TodoListId
            };
        _context.TodoListImages.Add(newTodo);
         await _context.SaveChangesAsync();
        return new Response<AddTodoListImageDto>(todo);
    }
    
    public async Task<Response<AddTodoListImageDto>> Update(AddTodoListImageDto todo)
    {
        
        var find = await _context.TodoListImages.FindAsync(todo.Id);
        find.Value = todo.Value;
        find.TodoListId = todo.TodoListId;
        await _context.SaveChangesAsync();
        return new Response<AddTodoListImageDto>(todo);
    }
    
    public async Task<TodoListImage> Delete(int id)
    {
        var todo = await _context.TodoListImages.FindAsync(id);
        _context.TodoListImages.Remove(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}