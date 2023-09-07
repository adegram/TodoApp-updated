using System.Net.Http.Json;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using ToDo.Shared.Dtos.Todos;
using ToDo.SPAv2.DataModel.Todos;
using ToDo.SPAv2.DataModel.Todos.Enum;
using ToDov2.SPA.ViewModels.Base;

namespace ToDo.SPAv2.ViewModels.TodoViewModels;

public class ToDoViewModel : BaseViewModel // MVC Pattern, functions from this class we will use in Index.razor
{
    private readonly HttpClient _httpClient;

    private bool EditMode = false; // Check if user edit some todo
    public ToDoStatus FilterStatus = ToDoStatus.None;
    public int FilterByDate = 0;
    public ToDoViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public List<Todo> Todos { get; set; } = new();
    public Todo TodoCreate { get; set; } = new();

    public override async Task OnInitializedAsync() // we send GET method to our API and convert it to our DataModel
    {
        try
        {
            var todoDtos = await _httpClient.GetFromJsonAsync<List<TodoDto>>("https://localhost:7012/api/Todo/GetAll");

            foreach (var todo in todoDtos)
            {
                Todos.Add(new Todo()
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Deadline = todo.Deadline,
                    Status = (ToDoStatus)todo.Status,
                    CreateDate = todo.CreateDate,
                });
            }
        }
        catch
        {
            Todos = new();
        }
    }
    public async Task AddNewTodo() // Add our new TodoModel and send it in our backed
    {
        if (String.IsNullOrEmpty(TodoCreate.Title) || TodoCreate.Title.Length < 3 || EditMode)
            return;

        var createDto = new CreateTodoDto()
        { 
            Title = TodoCreate.Title,
            Deadline = TodoCreate.Deadline,
        };

       await _httpClient.PostAsJsonAsync("https://localhost:7012/api/Todo/Create", createDto);
       Todos.Add(TodoCreate);
       TodoCreate = new();
       await FilterTodos();
    }

    public async Task UpdateRodo(Todo todo) // Validation and then send update to our backend
    {
        if (todo is not null && !String.IsNullOrEmpty(todo.Title))
        {
            await _httpClient.PutAsJsonAsync("https://localhost:7012/api/Todo/Update", todo);
            var todoResult = Todos.FirstOrDefault(prp => prp.Id == todo.Id);
            todoResult.Deadline = todo.Deadline;
            todoResult.Title = todo.Title;
            todoResult.IsEditMode = false;
            todoResult.Status = todo.Status;
        }

        todo.IsEditMode = false;
        EditMode = false;
    }

    public async Task ChangeStatus(bool finished, Todo todo) // If user click in checkbox, we will change our status and send this request to API
    {
        if (finished)
            todo.Status = ToDoStatus.Finished;
        else
            todo.Status = ToDoStatus.ToDo;
        await UpdateRodo(todo);
    }
    
    public async Task DeleteTodo(long id)
    {
        if(EditMode)
            return;
        var todo = Todos.FirstOrDefault(prp => prp.Id == id);
        if(todo is null)
            return;
        Todos.Remove(todo);
        await _httpClient.DeleteAsync($"https://localhost:7012/api/Todo/Delete?id={id}");
    }

    public async Task StartEdit(bool value, Todo todo) // Start edit mode, we need this, to block edit another one todoModel while one is editing
    {
        EditMode = value;
        todo.IsEditMode = value;
    }

    public async Task FilterTodos() // Filter our Todos
    {
        try
        {
            var todoDtos = await _httpClient.GetFromJsonAsync<List<TodoDto>>("https://localhost:7012/api/Todo/GetAll");
            Todos = new();
            foreach (var todo in todoDtos)
            {
                Todos.Add(new Todo()
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Deadline = todo.Deadline,
                    Status = (ToDoStatus)todo.Status,
                });
            }

            if (FilterStatus == ToDoStatus.Finished)
            {
                Todos = Todos.Where(prp => prp.Status == (ToDoStatus)3).ToList();
            }

            if (FilterStatus == ToDoStatus.ToDo)
            {
                Todos = Todos.Where(prp => prp.Status == (ToDoStatus)1).ToList();
            }

            if (FilterByDate == 1)
            {
                Todos = Todos.OrderBy(prp => prp.CreateDate.Date).ToList();
            }

            if (FilterByDate == 2)
            {
                Todos = Todos.Where(prp => prp.Deadline is not null).OrderBy(prp => prp.Deadline.Value.Date).ToList();
            }
        }
        catch
        {
            
        }
    }
}