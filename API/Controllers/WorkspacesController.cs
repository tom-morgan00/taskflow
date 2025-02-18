using Application.Workspaces.Commands;
using Application.Workspaces.DTOs;
using Application.Workspaces.Queries;
using Domain;
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
            var workspace = await Mediator.Send(new GetWorkspaceById.Query { Id = id });
            return Ok(workspace);
        }

        [HttpPost]
        public async Task<ActionResult<Workspace>> CreateWorkspace(CreateWorkspaceDto createWorkspaceDto)
        {
            var workspace = await Mediator.Send(new CreateWorkspace.Command { CreateWorkspaceDto = createWorkspaceDto });
            return Ok(workspace);
        }
    }
}
