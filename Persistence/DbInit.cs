using System;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class DbInit
{

    public static async Task SeedData(AppDbContext context, UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var users = new List<User> {

            new() {
                DisplayName = "Tom",
                Email = "thomas.morgan1903@gmail.com",
                UserName = "thomas.morgan1903@gmail.com",
                Bio = "I am a software developer",
                ImageUrl = "https://static.wikia.nocookie.net/disney/images/8/81/Danny_Trejo.jpg"
            },
            new () {
                DisplayName = "Tia",
                Email = "thomas.morgan1903+tia@gmail.com",
                UserName = "thomas.morgan1903+tia@gmail.com",
                Bio = "I am a teacher",
                ImageUrl = "https://cdn.britannica.com/16/221316-050-680EBB62/Steve-Buscemi-2012.jpg"
            },
            }
            ;

            foreach (User user in users)
            {
                await userManager.CreateAsync(user, "Password123!");

            }

        }
        ;

        if (context.Tasks.Any()) return;

        var workspace = new Workspace
        {
            Name = "Tom's Workspace",
            CreatedAt = DateTime.Now.AddMonths(-2)
        };
        context.Workspaces.Add(workspace);
        await context.SaveChangesAsync();

        var tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Name = "Design Homepage UI",
                Description = "Create the initial wireframe for the homepage",
                Status = TaskItemStatus.ToDo,
                DueDate = DateTime.Now.AddDays(7),
                CreatedAt = DateTime.Now.AddMonths(-2),
                WorkspaceId = workspace.Id,
            },
            new TaskItem
            {
                Name = "Implement Authentication",
                Description = "Set up .NET Identity for user authentication",
                Status = TaskItemStatus.InProgress,
                DueDate = DateTime.Now.AddDays(14),
                CreatedAt = DateTime.Now.AddMonths(-1),
                WorkspaceId = workspace.Id,
            },
            new TaskItem
            {
                Name = "Write Unit Tests",
                Description = "Write unit tests for the task management service",
                Status = TaskItemStatus.Done,
                DueDate = DateTime.Now.AddDays(-5),
                CreatedAt = DateTime.Now.AddMonths(-3),
                WorkspaceId = workspace.Id,
            },
            new TaskItem
            {
                Name = "Setup CI/CD Pipeline",
                Description = "Automate deployment process using GitHub Actions",
                Status = TaskItemStatus.ToDo,
                DueDate = DateTime.Now.AddDays(21),
                CreatedAt = DateTime.Now.AddMonths(-1),
                WorkspaceId = workspace.Id,
            },
            new TaskItem
            {
                Name = "Refactor API Controllers",
                Description = "Improve the structure of API controllers",
                Status = TaskItemStatus.InProgress,
                DueDate = DateTime.Now.AddDays(10),
                CreatedAt = DateTime.Now.AddDays(-20),
                WorkspaceId = workspace.Id,
            }
        };

        context.Workspaces.Attach(workspace);
        context.Tasks.AddRange(tasks);
        await context.SaveChangesAsync();

    }
}
