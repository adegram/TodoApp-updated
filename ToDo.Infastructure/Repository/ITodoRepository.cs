using ToDo.Domain.Models.Todos;

namespace ToDo.Infastructure.DAL.Repository;

public interface ITodoRepository
{
    public Task<IEnumerable<Todo>> GetAllAsync();
}