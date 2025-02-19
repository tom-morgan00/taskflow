using Application.Workspaces.Commands;
using Application.Workspaces.DTOs;
using Application.Workspaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspacesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<WorkspaceDto>>> GetAllWorkspaces()
        {
            var workspaces = await Mediator.Send(new GetAllWorkspaces.Query());
            return Ok(workspaces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkspaceDetailsDto>> GetWorkspaceById(string id)
        {
            var workspace = await Mediator.Send(new GetWorkspaceById.Query { Id = id });
            return Ok(workspace);
        }

        [HttpPost]
        public async Task<ActionResult<WorkspaceDto>> CreateWorkspace(CreateWorkspaceDto createWorkspaceDto)
        {
            var workspace = await Mediator.Send(new CreateWorkspace.Command { CreateWorkspaceDto = createWorkspaceDto });
            return Ok(workspace);
        }

        [HttpPut]
        public async Task<ActionResult<WorkspaceDto>> EditWorkspace(EditWorkspaceDto editWorkspaceDto)
        {
            var workspace = await Mediator.Send(new EditWorkspace.Command { EditWorkspaceDto = editWorkspaceDto });
            return Ok(workspace);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteWorkspace(string id)
        {
            var message = await Mediator.Send(new DeleteWorkspace.Command { Id = id });
            return Ok(message);
        }
    }
}
