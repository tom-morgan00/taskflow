using System;
using Application.Tasks.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Tasks.Commands;

public class CreateTask
{
    public class Command: IRequest<TaskItem>
    {
        public required CreateTaskDto CreateTaskDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, TaskItem>
        {
            public async Task<TaskItem> Handle(Command request, CancellationToken cancellationToken)
            {
                var workspace = await context.Workspaces.FindAsync(request.CreateTaskDto.WorkspaceId, cancellationToken);
                if (workspace == null) {
                    throw new Exception("Workspace not found");
                }
                var newTask = mapper.Map<TaskItem>(request.CreateTaskDto);
                newTask.Workspace = workspace;
                context.Tasks.Add(newTask);
                await context.SaveChangesAsync(cancellationToken);
                return newTask;
            }
        }
    }
}
