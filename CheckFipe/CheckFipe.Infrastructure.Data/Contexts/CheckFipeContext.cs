using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CheckFipe.Infrastructure.Data.Contexts
{
    public class CheckFipeContext : DbContext, ICheckFipeContext
    {
        public CheckFipeContext()
        {
        }

        public CheckFipeContext(DbContextOptions<CheckFipeContext> options) : base(options)
        {
        }

        public DbSet<ConsultaVeiculo> ConsultasVeiculo { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("CheckFipeContext");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);
            modelBuilder.Entity<ConsultaVeiculo>(new ConsultaVeiculoMap().Configure);
            modelBuilder.Entity<Modelo>(new ModeloMap().Configure);
            modelBuilder.Entity<Marca>(new MarcaMap().Configure);
        }
    }
}
