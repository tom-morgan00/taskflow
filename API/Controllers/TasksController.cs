using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(AppDbContext context): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetTasks()
        {
            return await context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskDetails(string id)
        {
            var activity = await context.Tasks.FindAsync(id);
            if (activity == null) return NotFound();
            return activity;
        }
    }
}
