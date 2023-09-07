using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models.Todos;

namespace ToDo.Domain.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Our databse Context
    {
        
    }
    
    public DbSet<Todo> Todos { get; set; }
}