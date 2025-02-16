using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tasks.Queries;

public class GetAllTasks
{
    public class Query : IRequest<List<TaskItem>> {}

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<TaskItem>>
    {
        public async Task<List<TaskItem>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Tasks.ToListAsync(cancellationToken);
        }
    }
}
