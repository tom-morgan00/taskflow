using System;
using Application.Workspaces.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workspaces.Queries;

public class GetAllWorkspaces
{
    public class Query : IRequest<List<WorkspaceDto>> { }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, List<WorkspaceDto>>
    {
        public async Task<List<WorkspaceDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var workspaces = await context.Workspaces.ToListAsync(cancellationToken);
            var workspaceDtos = mapper.Map<List<WorkspaceDto>>(workspaces);
            return workspaceDtos;
        }
    }
}
