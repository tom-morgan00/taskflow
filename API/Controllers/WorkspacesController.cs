using Application.Workspaces.Queries;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspacesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Workspace>>> GetAllWorkspaces()
        {
            var workspaces = await Mediator.Send(new GetAllWorkspaces.Query());
            return Ok(workspaces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workspace>> GetWorkspaceById(string id)
        {
            var workspace = await Mediator.Send(new GetWorkspaceById.Query{ Id = id });
            return Ok(workspace);
        }
    }
}
