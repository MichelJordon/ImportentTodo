using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Context;

public class DataContext:DbContext
{
    public DataContext( DbContextOptions<DataContext> options ) : base(options)
    {

    }
    public DbSet<Todo> Todos {get; set;}
    public DbSet<TodoList> TodoLists {get; set;}
    public DbSet<TodoListImage> TodoListImages{get; set;}
}