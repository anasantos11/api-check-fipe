using CheckFipe.Contracts;
using CheckFipe.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.Context
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
            modelBuilder.Entity<Veiculo>().ToTable("Veiculo");
            modelBuilder.Entity<Veiculo>().HasKey(veiculo => veiculo.IdVeiculo);
            modelBuilder.Entity<Veiculo>().Ignore(veiculo => veiculo.NumeroDeConsultas);

            modelBuilder.Entity<ConsultaVeiculo>().ToTable("ConsultaVeiculo");
            modelBuilder.Entity<ConsultaVeiculo>().HasKey(consultaVeiculo => consultaVeiculo.IdConsultaVeiculo);

            modelBuilder.Entity<ConsultaVeiculo>().HasKey(consultaVeiculo => consultaVeiculo.IdConsultaVeiculo);
            modelBuilder.Entity<ConsultaVeiculo>()
                .HasOne(consultaVeiculo => consultaVeiculo.Veiculo)
                .WithMany(veiculo => veiculo.ConsultasVeiculo)
                .HasForeignKey(consultaVeiculo => consultaVeiculo.IdVeiculo);
        }
    }
}
