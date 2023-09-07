namespace ToDo.Shared.Dtos.Todos;

public class TodoDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime CreateDate { get; set; }
    public int Status { get; set; }
}