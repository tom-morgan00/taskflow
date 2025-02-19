using System;
using Application.Tasks.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Tasks.Commands;

public class CreateTask
{
    public class Command : IRequest<TaskDto>
    {
        public required CreateTaskDto CreateTaskDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, TaskDto>
        {
            public async Task<TaskDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var workspace = await context.Workspaces.FindAsync(request.CreateTaskDto.WorkspaceId, cancellationToken);
                if (workspace == null)
                {
                    throw new Exception("Workspace not found");
                }
                var newTask = mapper.Map<TaskItem>(request.CreateTaskDto);
                context.Tasks.Add(newTask);
                await context.SaveChangesAsync(cancellationToken);
                var taskDto = mapper.Map<TaskDto>(newTask);
                return taskDto;
            }
        }
    }
}
