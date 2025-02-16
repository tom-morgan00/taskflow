using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Tasks.Queries;

public class GetTaskById
{
    public class Query : IRequest<TaskItem> {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, TaskItem>
    {
        public async Task<TaskItem> Handle(Query request, CancellationToken cancellationToken)
        {
            var task = await context.Tasks.FindAsync([request.Id], cancellationToken);
            if (task == null) {
                throw new Exception("Task not found.");
            }
            return task;
        }
    }
}
