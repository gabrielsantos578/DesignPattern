using Microsoft.EntityFrameworkCore;
using DesignPattern.Context.Builders;
using DesignPattern.Objects.Models.Entities;

namespace DesignPattern.Context;
public class AppDBContext : DbContext
{
	public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    // Mapeamento Relacional dos Objetos no Bando de Dados
    public DbSet<TaskModel> Task { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        TaskBuilder.Build(modelBuilder);
    }
}
