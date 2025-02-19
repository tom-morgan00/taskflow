using System;

namespace Application.Tasks.DTOs;

public class EditTaskDto
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "";
    public string WorkspaceId { get; set; } = "";
}
