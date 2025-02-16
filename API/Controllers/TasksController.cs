using Application.Tasks.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(): ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
                ?? throw new InvalidOperationException("IMediator service is unavailable.");

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
    }
}
