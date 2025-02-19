using System;
using Application.Tasks.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Tasks.Commands;

public class EditTask
{
    public class Command : IRequest<TaskDto>
    {
        public required EditTaskDto EditTaskDto { get; set; }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, TaskDto>
        {
            public async Task<TaskDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var task = await context.Tasks.FindAsync([request.EditTaskDto.Id], cancellationToken);
                if (task == null)
                {
                    throw new Exception("Task not found");
                }
                mapper.Map(request.EditTaskDto, task);
                var result = await context.SaveChangesAsync(cancellationToken) > 0;
                if (!result)
                {
                    throw new Exception("Failed to update task");
                }
                var taskDto = mapper.Map<TaskDto>(task);
                return taskDto;
            }
        }
    }
}
