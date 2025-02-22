using System;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Tasks.Commands;

public class DeleteTask
{
    public class Command : IRequest<Result<string>>
    {
        public required string Id { get; set; }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Result<string>>
        {
            public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var task = await context.Tasks.FindAsync([request.Id], cancellationToken);
                if (task == null)
                {
                    return Result<string>.Failure("Task not found", 404);
                }
                context.Remove(task);
                var result = await context.SaveChangesAsync(cancellationToken) > 0;
                if (!result)
                {
                    Result<string>.Failure("Failed to delete task", 400);
                }
                return Result<string>.Success("Task has been deleted");
            }
        }
    }
}
