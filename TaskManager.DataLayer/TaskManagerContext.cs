using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TaskManager.EntityModel;

namespace TaskManager.DataLayer
{

    public partial class TaskManagerContext : DbContext
    {
        public TaskManagerContext()
            : base("name=TaskManagerEF")
        {
            Database.SetInitializer(new TaskManagerContextInitializer());
        }

        public DbSet<TaskData> TaskData { get; set; }
        public DbSet<ParentTaskData> ParentTaskData {get;set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<TaskData>();
            modelBuilder.Entity<ParentTaskData>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
