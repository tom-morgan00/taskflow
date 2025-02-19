using System;
using MediatR;
using Persistence;

namespace Application.Tasks.Commands;

public class DeleteTask
{
    public class Command : IRequest<string>
    {
        public required string Id { get; set; }

        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var task = await context.Tasks.FindAsync([request.Id], cancellationToken);
                if (task == null)
                {
                    throw new Exception("Task not found");
                }
                context.Remove(task);
                var result = await context.SaveChangesAsync(cancellationToken) > 0;
                if (!result)
                {
                    throw new Exception("Failed to delete task");
                }
                return "Task has been deleted";
            }
        }
    }
}
