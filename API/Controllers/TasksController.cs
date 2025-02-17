using Application.Tasks.Commands;
using Application.Tasks.DTOs;
using Application.Tasks.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(): BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTasks()
        {
            var tasks = await Mediator.Send(new GetAllTasks.Query());
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskById(string id)
        {
            var task = await Mediator.Send(new GetTaskById.Query{ Id = id });
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(CreateTaskDto createTaskDto)
        {
            var task = await Mediator.Send(new CreateTask.Command{ CreateTaskDto = createTaskDto});
            return Ok(task);
        }
    }
}
