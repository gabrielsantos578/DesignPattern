using Microsoft.EntityFrameworkCore;
using DesignPattern.Objects.Models.Entities;

namespace DesignPattern.Context.Builders
{
    public class TaskBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<TaskModel>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskModel>().Property(t => t.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<TaskModel>().Property(t => t.Description).HasMaxLength(300).IsRequired();


            // Inserções
            /*modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel { Id = 1, Name = "Teste", Description = "Construção do teste." },
            );*/
        }
    }

}
