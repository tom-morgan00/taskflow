using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<TaskItem> Tasks { get; set; }
    public required DbSet<Workspace> Workspaces { get; set; }

}
