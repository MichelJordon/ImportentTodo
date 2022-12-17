namespace Domain.Entities;
public class TodoListImage
{
    public int  Id { get; set; }
    public string Value { get; set; }
    public int TodoListId { get; set; }
    public TodoList TodoList {get; set;} 
}