using System.Collections;
using ToDo.Domain.Models.Todos;
using ToDo.Shared.Dtos.Todos;

namespace ToDo.Core.Services;

public interface ITodoService
{
    public Task<IEnumerable<TodoDto>> GetAll();
    public Task CreateAsync(CreateTodoDto model);
    public Task UpdateAsync(TodoDto model);
    public Task DeleteAsync(long id);
}