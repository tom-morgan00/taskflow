using System;
using Application.Core;
using Application.Tasks.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tasks.Queries;

public class GetAllTasks
{
    public class Query : IRequest<Result<List<TaskDto>>> { }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, Result<List<TaskDto>>>
    {
        public async Task<Result<List<TaskDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var tasks = await context.Tasks.ToListAsync(cancellationToken);
            var taskDtos = mapper.Map<List<TaskDto>>(tasks);
            return Result<List<TaskDto>>.Success(taskDtos);
        }
    }
}
