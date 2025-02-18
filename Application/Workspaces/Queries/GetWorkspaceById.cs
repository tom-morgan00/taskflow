using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workspaces.Queries;

public class GetWorkspaceById
{
    public class Query : IRequest<Workspace>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Workspace>
    {
        public async Task<Workspace> Handle(Query request, CancellationToken cancellationToken)
        {
            var workspace = await context.Workspaces
                .Where(w => w.Id == request.Id)
                .Include(w => w.Tasks)
                .FirstOrDefaultAsync();

            if (workspace == null)
            {
                throw new Exception("Workspace not found.");
            }

            return workspace;
        }
    }
}
