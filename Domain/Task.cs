using System;
using System.Text.Json.Serialization;

namespace Domain;

public class TaskItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    public DateTime? DueDate { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required string WorkspaceId { get; set; }
    [JsonIgnore]
    public Workspace Workspace { get; set; } = null!;
}

public enum TaskItemStatus
{
    ToDo,
    InProgress,
    Done
}
