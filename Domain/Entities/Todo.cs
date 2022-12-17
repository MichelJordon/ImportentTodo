using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Todo
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public  DateTime CreatedAt {get; set; }
    public int TodoListId {get; set;}
    public TodoList TodoList {get; set;}
    public string ImageName { get; set; }
    [NotMapped]
    public IFormFile Image { get; set; }
}

public enum Status
{
    Todo = 1,
    InProgress,
    Done
}