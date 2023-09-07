using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Services;
using ToDo.Shared.Dtos.Todos;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
        {
            return Ok(await _todoService.GetAll());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync(CreateTodoDto dto)
        {
            await _todoService.CreateAsync(dto);
            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync(TodoDto dto)
        {
            await _todoService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }
        
    }
}
