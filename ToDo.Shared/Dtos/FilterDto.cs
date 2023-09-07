namespace ToDo.Shared.Dtos.Todos;

public class FilterDto
{
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public DateTime? Deadline { get; set; }
    public int Page { get; set; }
}