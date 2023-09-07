using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models.Todos;
using ToDo.Shared.Dtos.Todos;

namespace ToDo.Domain.IRepository
{
    public interface ITodoRepository
    {
        public Task<IEnumerable<Todo>> GetAllAsync();
        public Task<Todo> GetAsync(long id);
        public Task CreateAsync(Todo model);
        public Task UpdateAsync(Todo model);
        public Task DeleteAsync(Todo model);
    }
}
