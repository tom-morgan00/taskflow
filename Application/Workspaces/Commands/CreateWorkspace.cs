using System;
using Application.Workspaces.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Workspaces.Commands;

public class CreateWorkspace
{
    public class Command: IRequest<Workspace>
    {
        public required CreateWorkspaceDto CreateWorkspaceDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Workspace>
        {
            public async Task<Workspace> Handle(Command request, CancellationToken cancellationToken)
            {
                var newWorkspace = mapper.Map<Workspace>(request.CreateWorkspaceDto);
                context.Workspaces.Add(newWorkspace);
                await context.SaveChangesAsync(cancellationToken);
                return newWorkspace;
            }
        }
    }
}
