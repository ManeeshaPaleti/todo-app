using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
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

        [HttpGet]
        public ActionResult<List<TodoItemsModel>> GetAllItems()
        {
            var result = _todoService.GetAllItems();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<TodoItemsModel> AddNewItem([FromBody] TodoItemsModel todoItemsModel)
        {
            if (todoItemsModel == null)
            {
                return BadRequest("Item name is required");
            }
            var result = _todoService.AddNewItem(todoItemsModel.TodoTask);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteItem = _todoService.DeleteItem(id);
            if (deleteItem)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
