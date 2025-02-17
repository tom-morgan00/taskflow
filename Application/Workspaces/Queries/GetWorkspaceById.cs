using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Workspaces.Queries;

public class GetWorkspaceById
{
    public class Query : IRequest<Workspace> {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context): IRequestHandler<Query, Workspace>
    {
        public async Task<Workspace> Handle(Query request, CancellationToken cancellationToken)
        {
            var workspace = await context.Workspaces.FindAsync([request.Id]);
            if (workspace == null) {
                throw new Exception("Task not found.");
            }
            return workspace;
        }
    }
}
