using System.Data.Entity;
using TaskManager.Models;

namespace TaskManager.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("DefaultConnection") { }
        public DbSet<Task> Tasks { get; set; }
    }
}