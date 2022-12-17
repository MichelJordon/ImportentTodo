using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Domain.Entities;

public class AddTodoDto
{
    public AddTodoDto ()
    {
        CreatedAt = DateTime.Now;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public int TodoListId { get; set; }
    public IFormFile? Image { get; set; }
}