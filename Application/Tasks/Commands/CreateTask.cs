using System;
using Application.Core;
using Application.Tasks.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Tasks.Commands;

public class CreateTask
{
    public class Command : IRequest<Result<TaskDto>>
    {
        public required CreateTaskDto CreateTaskDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<TaskDto>>
        {
            public async Task<Result<TaskDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var workspace = await context.Workspaces.FindAsync(request.CreateTaskDto.WorkspaceId, cancellationToken);
                if (workspace == null)
                {
                    return Result<TaskDto>.Failure("Workspace not found", 404);
                }
                var newTask = mapper.Map<TaskItem>(request.CreateTaskDto);
                context.Tasks.Add(newTask);
                await context.SaveChangesAsync(cancellationToken);
                var taskDto = mapper.Map<TaskDto>(newTask);
                return Result<TaskDto>.Success(taskDto);
            }
        }
    }
}
