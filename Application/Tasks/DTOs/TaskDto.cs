using System;

namespace Application.Tasks.DTOs;

public class TaskDto
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "";
    public string WorkspaceId { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}
