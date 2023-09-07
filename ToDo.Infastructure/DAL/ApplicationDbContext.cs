using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models.Todos;

namespace ToDo.Infastructure.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Todo> Todos { get; set; }
}