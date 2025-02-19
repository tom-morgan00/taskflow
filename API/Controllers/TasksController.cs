using Application.Tasks.Commands;
using Application.Tasks.DTOs;
using Application.Tasks.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController() : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasks()
        {
            var tasks = await Mediator.Send(new GetAllTasks.Query());
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(string id)
        {
            var task = await Mediator.Send(new GetTaskById.Query { Id = id });
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            var task = await Mediator.Send(new CreateTask.Command { CreateTaskDto = createTaskDto });
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult<TaskDto>> EditTask(EditTaskDto editTaskDto)
        {
            var task = await Mediator.Send(new EditTask.Command { EditTaskDto = editTaskDto });
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTask(string id)
        {
            var message = await Mediator.Send(new DeleteTask.Command { Id = id });
            return Ok(message);
        }
    }
}
