using System.ComponentModel.DataAnnotations;
using ToDo.SPA.DataModel.Todos.Enum;

namespace ToDo.SPA.DataModel.Todos;


// Model our Todos
public class Todo
{
    public int Id { get; set; }
    [MinLength(3, ErrorMessage = "Min lenght 3")]
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    public DateTime? Deadline { get; set; }
    public ToDoStatus Status { get; set; } 
}