using Domain.Entities;

public class GetTodoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public int TodoListId { get; set; }
    public string ImageName { get; set; }
}