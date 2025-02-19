using System;
using MediatR;
using Persistence;

namespace Application.Workspaces.Commands;

public class DeleteWorkspace
{
    public class Command : IRequest<string>
    {
        public required string Id { get; set; }

        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var workspace = await context.Workspaces.FindAsync([request.Id], cancellationToken);

                if (workspace == null)
                {
                    throw new Exception("Workspace not found");
                }

                context.Remove(workspace);
                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                if (!result)
                {
                    throw new Exception("Failed to delete workspace");
                }

                return "Workspace has been deleted";
            }
        }
    }
}
