using System;
using Application.Core;
using Application.Tasks.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tasks.Commands;

public class EditTask
{
    public class Command : IRequest<Result<TaskDto>>
    {
        public required EditTaskDto EditTaskDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<TaskDto>>
        {
            public async Task<Result<TaskDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var task = await context.Tasks.FindAsync([request.EditTaskDto.Id], cancellationToken);
                if (task == null)
                {
                    return Result<TaskDto>.Failure("Task not found", 404);
                }
                mapper.Map(request.EditTaskDto, task);
                var taskDto = mapper.Map<TaskDto>(task);
                if (context.Entry(task).State == EntityState.Unchanged)
                {
                    return Result<TaskDto>.Success(taskDto);
                }
                var result = await context.SaveChangesAsync(cancellationToken) > 0;
                if (!result)
                {
                    return Result<TaskDto>.Failure("Failed to update task", 400);
                }
                return Result<TaskDto>.Success(taskDto);
            }
        }
    }
}
