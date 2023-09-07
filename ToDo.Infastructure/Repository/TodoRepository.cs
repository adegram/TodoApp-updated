using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models.Todos;

namespace ToDo.Infastructure.DAL.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TodoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        return await _dbContext.Todos.ToListAsync();
    }
}