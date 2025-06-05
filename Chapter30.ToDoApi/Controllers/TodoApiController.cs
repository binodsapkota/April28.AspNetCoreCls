using Chapter30.ToDoApi.DTOs;
using Chapter30.ToDoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chapter30.ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoApiController : ControllerBase
    {
        private static List<TodoItem> _todoItems = new List<TodoItem>();
        private static int _nextId = 1;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoItems);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _todoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(TodoItemDto todoItemDto)
        {
            var todoItem = new TodoItem
            {
                Id = _nextId++,
                Title = todoItemDto.Title,
                User = User.Identity.Name, //  
                IsComplete = false
            };
            //retrieving information from claims
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            var userName = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            var fullName = User.Claims.ToList().FirstOrDefault(x => x.Type == "full name").Value;
            _todoItems.Add(todoItem);
            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
            //return with statucode 201 Created
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItemDto todoItemDto)
        {
            var item = _todoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.Title = todoItemDto.Title;
            item.IsComplete = todoItemDto.IsComplete;
            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _todoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _todoItems.Remove(item);
            return NoContent(); // 204 No Content
        }


    }
}
