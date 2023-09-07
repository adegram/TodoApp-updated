using ToDo.Domain.IRepository;
using ToDo.Domain.Models.Todos;
using ToDo.Shared.Dtos.Todos;

namespace ToDo.Core.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<TodoDto>> GetAll() // Get all ours todos and covert into TodoDto model 
    {
        var todos = await _repository.GetAllAsync();
        if (todos is null)
            throw new Exception();

        List<TodoDto> todosInDto = new();
        
        foreach (var todo in todos)
        {
            todosInDto.Add(new()
            {
                Id = todo.Id,
                Title = todo.Title,
                Deadline = todo.Deadline,
                Status = todo.Status,
                CreateDate = todo.CreateDate,
            });
        }
        return todosInDto;
    }

    public async Task CreateAsync(CreateTodoDto model)
    {
        if (model is null)
            throw new Exception();
        
        var todo = new Todo()
        {
            Deadline = model.Deadline,
            Status = 1,
            CreateDate = DateTime.Now,
            Title = model.Title,
        };

        await _repository.CreateAsync(todo);
    }

    public async Task UpdateAsync(TodoDto model)
    {
        if (model is null)
            throw new Exception();

        var todo = new Todo()
        {
            Id = model.Id,
            Deadline = model.Deadline,
            Title = model.Title,
            Status = model.Status,
        };
        await _repository.UpdateAsync(todo);
    }

    public async Task DeleteAsync(long id)
    {
        var todo = await _repository.GetAsync(id);

        if (todo is null)
            throw new Exception();

        await _repository.DeleteAsync(todo);
    }
}