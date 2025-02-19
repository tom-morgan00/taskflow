using System;
using Application.Workspaces.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Workspaces.Commands;

public class CreateWorkspace
{
    public class Command : IRequest<WorkspaceDto>
    {
        public required CreateWorkspaceDto CreateWorkspaceDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, WorkspaceDto>
        {
            public async Task<WorkspaceDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var newWorkspace = mapper.Map<Workspace>(request.CreateWorkspaceDto);
                context.Workspaces.Add(newWorkspace);
                await context.SaveChangesAsync(cancellationToken);
                var workspaceDto = mapper.Map<WorkspaceDto>(newWorkspace);
                return workspaceDto;
            }
        }
    }
}
