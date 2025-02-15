using System;

namespace Domain;

public class TaskItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required TaskItemStatus Status { get; set; } = TaskItemStatus.Todo;
    public DateTime DueDate { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
}

public enum TaskItemStatus
{
    Todo,
    InProgress,
    Done
}
