using Microsoft.EntityFrameworkCore;
using ToDo.Domain.DAL;
using ToDo.Domain.Models.Todos;
using ToDo.Shared.Dtos.Todos;

namespace ToDo.Domain.IRepository;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TodoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        var todos = await _dbContext.Todos.ToListAsync();
        todos.Reverse();
        return todos;
    }

    public async Task<Todo> GetAsync(long id)
    {
        return await _dbContext.Todos.FirstOrDefaultAsync(prp => prp.Id == id);
    }

    public async Task CreateAsync(Todo model)
    {
        await _dbContext.Todos.AddAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Todo model)
    {
        _dbContext.Todos.Update(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Todo model)
    {
        _dbContext.Todos.Remove(model);
        await _dbContext.SaveChangesAsync();
    }
}