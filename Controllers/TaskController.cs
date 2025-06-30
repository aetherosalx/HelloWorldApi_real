using HelloWorldApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private static readonly List<TaskItem> Tasks = new()
        {
            new TaskItem { Id = 1, Title = "Write resume", IsComplete = true },
            new TaskItem { Id = 2, Title = "Apply for job", IsComplete = false }
        };

        [HttpGet]
        public IActionResult GetAll() => Ok(Tasks);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(TaskItem newTask)
        {
            newTask.Id = Tasks.Max(t => t.Id) + 1;
            Tasks.Add(newTask);
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updatedTask)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.IsComplete = updatedTask.IsComplete;

            return NoContent(); // 204 No Content is standard for successful update
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            Tasks.Remove(task);
            return NoContent();
        }
    }
}
