using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Workspaces.Queries;

public class GetAllWorkspaces
{
    public class Query : IRequest<List<Workspace>> {}

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Workspace>>
    {
        public async Task<List<Workspace>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Workspaces.ToListAsync(cancellationToken);
        }
    }
}
