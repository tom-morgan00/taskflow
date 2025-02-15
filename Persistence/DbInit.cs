using System;
using Domain;

namespace Persistence;

public class DbInit
{
    
    public static async Task SeedData(AppDbContext context) 
    {
        if (context.Tasks.Any()) return;

        var tasks = new List<TaskItem>
{
    new TaskItem
    {
        Name = "Design Homepage UI",
        Description = "Create the initial wireframe for the homepage",
        Status = TaskItemStatus.Todo,
        DueDate = DateTime.Now.AddDays(7),
        CreatedAt = DateTime.Now.AddMonths(-2)
    },
    new TaskItem
    {
        Name = "Implement Authentication",
        Description = "Set up .NET Identity for user authentication",
        Status = TaskItemStatus.InProgress,
        DueDate = DateTime.Now.AddDays(14),
        CreatedAt = DateTime.Now.AddMonths(-1)
    },
    new TaskItem
    {
        Name = "Write Unit Tests",
        Description = "Write unit tests for the task management service",
        Status = TaskItemStatus.Done,
        DueDate = DateTime.Now.AddDays(-5),
        CreatedAt = DateTime.Now.AddMonths(-3)
    },
    new TaskItem
    {
        Name = "Setup CI/CD Pipeline",
        Description = "Automate deployment process using GitHub Actions",
        Status = TaskItemStatus.Todo,
        DueDate = DateTime.Now.AddDays(21),
        CreatedAt = DateTime.Now.AddMonths(-1)
    },
    new TaskItem
    {
        Name = "Refactor API Controllers",
        Description = "Improve the structure of API controllers",
        Status = TaskItemStatus.InProgress,
        DueDate = DateTime.Now.AddDays(10),
        CreatedAt = DateTime.Now.AddDays(-20)
    }
};

context.Tasks.AddRange(tasks);
await context.SaveChangesAsync();

    }
}
