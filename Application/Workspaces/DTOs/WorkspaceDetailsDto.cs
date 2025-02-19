using System;
using Application.Tasks.DTOs;

namespace Application.Workspaces.DTOs;

public class WorkspaceDetailsDto
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public ICollection<TaskDto>? Tasks { get; private set; } = [];
}
