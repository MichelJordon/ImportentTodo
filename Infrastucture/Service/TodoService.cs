using Domain.Entities;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Infrastructure.Services;

public class TodoService
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _environment;
    private readonly IMapper _mapper;
 
    public TodoService(DataContext context, IWebHostEnvironment environment, IMapper mapper)
    {
        _context = context;
        _environment = environment;
        _mapper = mapper;
    }
    
    public async Task<Response<List<GetTodoDto>>> GetTodos()
    {
       var todos = _mapper.Map<List<GetTodoDto>>(_context.Todos.ToList());
       return new Response<List<GetTodoDto>>(todos);
    }

    public async Task<Response<GetTodoDto>> AddTodo(AddTodoDto todo)
    {
        var newTodo = _mapper.Map<Todo>(todo); // мавзуи AutoMapping ки корои бологира да 1 хат мекна!
        newTodo.ImageName = await UploadFile(todo.Image);
        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();
        return new Response<GetTodoDto>(_mapper.Map<GetTodoDto>(newTodo));
    }
    public async Task<GetTodoDto> Update(AddTodoDto todo)
    {
        var find = await _context.Todos.FindAsync(todo.Id);
        find.Title = todo.Title;
        find.Description = todo.Description;
        find.CreatedAt = todo.CreatedAt;
        find.Status = todo.Status;
        find.TodoListId = todo.TodoListId;
        if (todo.Image != null)
        {
            find.ImageName = await UpdateFile(todo.Image, find.ImageName);
        }
        await _context.SaveChangesAsync();
        return _mapper.Map<GetTodoDto>(todo);

    }
    private async Task<string> UploadFile(IFormFile file)
    {
        if (file == null) return null;
        
        var path = Path.Combine(_environment.WebRootPath, "todo");
        if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
        
        var filepath = Path.Combine(path, file.FileName);
        using (var stream = new FileStream(filepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var updated = await _context.SaveChangesAsync();
        return file.FileName;
    }
    private async Task<string> UpdateFile(IFormFile file, string oldFileName)
    {
        //delete old image if exists
        var filepath = Path.Combine(_environment.WebRootPath, "todo", oldFileName);
        if(File.Exists(filepath) == true) File.Delete(filepath);
        
        var newFilepath = Path.Combine(_environment.WebRootPath, "todo", file.FileName);
        using (var stream = new FileStream(newFilepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;

    }
    
    public async Task<Response<string>> Delete(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return new Response<string>("Dalated");
    }
}