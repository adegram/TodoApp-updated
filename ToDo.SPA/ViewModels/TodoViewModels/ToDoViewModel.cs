using ToDo.SPA.DataModel.Todos;
using ToDo.SPA.DataModel.Todos.Enum;
using ToDo.SPA.ViewModels.Base;

namespace ToDo.SPA.ViewModels.TodoViewModels;

public class ToDoViewModel : BaseViewModel
{
    public List<Todo> Todos { get; set; } = new();
    public Todo TodoCreate { get; set; } = new();

    public override async Task OnInitializedAsync()
    {
        
    }
    public void AddNewTodo()
    {
        Todos.Add(TodoCreate);
    }

    public void DeleteTodo(long id)
    {
        var todo = Todos.FirstOrDefault(prp => prp.Id == id);
        if(todo is null)
            return;
        Todos.Remove(todo);
    }
}