using System;

namespace Application.Tasks.DTOs;

public class CreateTaskDto
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = "";
    public string WorkspaceId { get; set; } = "";
}
