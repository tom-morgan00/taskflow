using System;
using Application.Tasks.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tasks.Queries;

public class GetAllTasks
{
    public class Query : IRequest<List<TaskDto>> { }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, List<TaskDto>>
    {
        public async Task<List<TaskDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var tasks = await context.Tasks.ToListAsync(cancellationToken);
            var taskDtos = mapper.Map<List<TaskDto>>(tasks);
            return taskDtos;
        }
    }
}
