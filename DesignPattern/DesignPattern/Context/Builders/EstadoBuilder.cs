using Microsoft.EntityFrameworkCore;
using SGED.Objects.Models.Entities;

namespace SGED.Context.Builders
{
    public class EstadoBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            // Builder
            modelBuilder.Entity<Objects.Models.Entities.Task>().HasKey(e => e.Id);
            modelBuilder.Entity<Objects.Models.Entities.Task>().Property(e => e.NomeEstado).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Objects.Models.Entities.Task>().Property(e => e.UfEstado).HasMaxLength(2).IsRequired();


            // Inserções
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, NomeEstado = "São Paulo", UfEstado = "SP" },
                new Task { Id = 2, NomeEstado = "Alagoas", UfEstado = "AL" },
                new Task { Id = 3, NomeEstado = "Amapá", UfEstado = "AP" },
                new Task { Id = 4, NomeEstado = "Amazonas", UfEstado = "AM" },
                new Task { Id = 5, NomeEstado = "Bahia", UfEstado = "BA" },
                new Task { Id = 6, NomeEstado = "Ceará", UfEstado = "CE" },
                new Task { Id = 7, NomeEstado = "Distrito Federal", UfEstado = "DF" },
                new Task { Id = 8, NomeEstado = "Espírito Santo", UfEstado = "ES" },
                new Task { Id = 9, NomeEstado = "Goiás", UfEstado = "GO" },
                new Task { Id = 10, NomeEstado = "Maranhão", UfEstado = "MA" },
                new Task { Id = 11, NomeEstado = "Mato Grosso", UfEstado = "MT" },
                new Task { Id = 12, NomeEstado = "Mato Grosso do Sul", UfEstado = "MS" },
                new Task { Id = 13, NomeEstado = "Minas Gerais", UfEstado = "MG" },
                new Task { Id = 14, NomeEstado = "Pará", UfEstado = "PA" },
                new Task { Id = 15, NomeEstado = "Paraíba", UfEstado = "PB" },
                new Task { Id = 16, NomeEstado = "Paraná", UfEstado = "PR" },
                new Task { Id = 17, NomeEstado = "Pernambuco", UfEstado = "PE" },
                new Task { Id = 18, NomeEstado = "Piauí", UfEstado = "PI" },
                new Task { Id = 19, NomeEstado = "Rio de Janeiro", UfEstado = "RJ" },
                new Task { Id = 20, NomeEstado = "Rio Grande do Norte", UfEstado = "RN" },
                new Task { Id = 21, NomeEstado = "Rio Grande do Sul", UfEstado = "RS" },
                new Task { Id = 22, NomeEstado = "Rondônia", UfEstado = "RO" },
                new Task { Id = 23, NomeEstado = "Roraima", UfEstado = "RR" },
                new Task { Id = 24, NomeEstado = "Santa Catarina", UfEstado = "SC" },
                new Task { Id = 25, NomeEstado = "Acre", UfEstado = "AC" },
                new Task { Id = 26, NomeEstado = "Sergipe", UfEstado = "SE" },
                new Task { Id = 27, NomeEstado = "Tocantins", UfEstado = "TO" }
            );
        }
    }

}
