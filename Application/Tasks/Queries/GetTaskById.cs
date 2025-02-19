using System;
using Application.Tasks.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Tasks.Queries;

public class GetTaskById
{
    public class Query : IRequest<TaskDto>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, TaskDto>
    {
        public async Task<TaskDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var task = await context.Tasks.FindAsync([request.Id], cancellationToken);
            if (task == null)
            {
                throw new Exception("Task not found.");
            }
            var taskDto = mapper.Map<TaskDto>(task);
            return taskDto;
        }
    }
}
