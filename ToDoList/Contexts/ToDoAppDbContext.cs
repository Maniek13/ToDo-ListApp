using Microsoft.EntityFrameworkCore;
using ToDoList.DbModels;
using ToDoList.Settings;

namespace ToDoList.Contexts
{
    internal class ToDoAppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
        }
    }
}
