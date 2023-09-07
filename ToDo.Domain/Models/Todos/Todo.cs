namespace ToDo.Domain.Models.Todos;

public class Todo // Our todo model
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime CreateDate { get; set; }
    public int Status { get; set; }
}