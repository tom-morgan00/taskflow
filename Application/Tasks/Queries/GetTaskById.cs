using System;
using Application.Core;
using Application.Tasks.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Tasks.Queries;

public class GetTaskById
{
    public class Query : IRequest<Result<TaskDto>>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, Result<TaskDto>>
    {
        public async Task<Result<TaskDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var task = await context.Tasks.FindAsync([request.Id], cancellationToken);
            if (task == null)
            {
                return Result<TaskDto>.Failure("Task not found", 404);
            }
            var taskDto = mapper.Map<TaskDto>(task);
            return Result<TaskDto>.Success(taskDto);
        }
    }
}
