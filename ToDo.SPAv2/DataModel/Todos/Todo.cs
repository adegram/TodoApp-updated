using System.ComponentModel.DataAnnotations;
using ToDo.SPAv2.DataModel.Todos.Enum;

namespace ToDo.SPAv2.DataModel.Todos;


// Model our Todos
public class Todo
{
    public long Id { get; set; }
    [MinLength(3, ErrorMessage = "Min length 3")]
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    public DateTime? Deadline { get; set; }
    public ToDoStatus Status { get; set; }
    public bool IsFinished { get; set; } = false;
    public bool IsEditMode { get; set; } = false;
    public DateTime CreateDate { get; set; }
}