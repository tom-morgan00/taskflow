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
            return HandleResult(await Mediator.Send(new GetAllTasks.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(string id)
        {
            return HandleResult(await Mediator.Send(new GetTaskById.Query { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            return HandleResult(await Mediator.Send(new CreateTask.Command { CreateTaskDto = createTaskDto }));
        }

        [HttpPut]
        public async Task<ActionResult<TaskDto>> EditTask(EditTaskDto editTaskDto)
        {
            return HandleResult(await Mediator.Send(new EditTask.Command { EditTaskDto = editTaskDto }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTask(string id)
        {
            return HandleResult(await Mediator.Send(new DeleteTask.Command { Id = id }));
        }
    }
}
