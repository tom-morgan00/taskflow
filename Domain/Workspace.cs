using System;

namespace Domain;

public class Workspace
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<TaskItem> Tasks { get; } = [];
}
