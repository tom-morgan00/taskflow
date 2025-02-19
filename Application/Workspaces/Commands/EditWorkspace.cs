using System;
using Application.Workspaces.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Workspaces.Commands;

public class EditWorkspace
{
    public class Command : IRequest<WorkspaceDto>
    {
        public required EditWorkspaceDto EditWorkspaceDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, WorkspaceDto>
        {
            public async Task<WorkspaceDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var workspace = await context.Workspaces.FindAsync([request.EditWorkspaceDto.Id], cancellationToken);

                if (workspace == null)
                {
                    throw new Exception("Workspace not found");
                }

                mapper.Map(request.EditWorkspaceDto, workspace);
                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                if (!result)
                {
                    throw new Exception("Failed to update workspace");
                }

                var workspaceDto = mapper.Map<WorkspaceDto>(workspace);

                return workspaceDto;
            }
        }
    }
}
