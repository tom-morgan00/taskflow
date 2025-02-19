using System;
using Application.Workspaces.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workspaces.Queries;

public class GetWorkspaceById
{
    public class Query : IRequest<WorkspaceDetailsDto>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, WorkspaceDetailsDto>
    {
        public async Task<WorkspaceDetailsDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var workspace = await context.Workspaces
                .Where(w => w.Id == request.Id)
                .Include(w => w.Tasks)
                .FirstOrDefaultAsync();

            if (workspace == null)
            {
                throw new Exception("Workspace not found.");
            }

            var workspaceDto = mapper.Map<WorkspaceDetailsDto>(workspace);

            return workspaceDto;
        }
    }
}
