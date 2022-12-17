using Domain.Entities;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoListService
{
    private readonly DataContext _context;

    public TodoListService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Response<List<GetTodoListDto>>> GetTodoLists()
    {
       var todos = await _context.TodoLists.ToListAsync();
        var list = new List<GetTodoListDto>();
        foreach (var t in todos)
        {
            var todo = new GetTodoListDto()
            {
                Id = t.Id,
                Title = t.Title,
                Color = t.Color
            };
            list.Add(todo);
        }
       return new Response<List<GetTodoListDto>>(list);
    }

    public async Task<Response<AddTodoListDto>> AddTodoLists(AddTodoListDto todo)
    {
            var newTodo = new TodoList()
            {
                Title = todo.Title,
                Color = todo.Color
            };
        _context.TodoLists.Add(newTodo);
         await _context.SaveChangesAsync();
        return new Response<AddTodoListDto>(todo);
    }
    
    public async Task<Response<AddTodoListDto>> Update(AddTodoListDto todo)
    {
        
        var find = await _context.TodoLists.FindAsync(todo.Id);
        find.Title = todo.Title;
        find.Color = todo.Color;
        await _context.SaveChangesAsync();
        return new Response<AddTodoListDto>(todo);
    }
    
    public async Task<TodoList> Delete(int id)
    {
        var todo = await _context.TodoLists.FindAsync(id);
        _context.TodoLists.Remove(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}