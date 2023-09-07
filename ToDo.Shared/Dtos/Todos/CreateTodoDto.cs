namespace ToDo.Shared.Dtos.Todos;

public class CreateTodoDto
{
    public string Title { get; set; }
    public DateTime? Deadline { get; set; }
}