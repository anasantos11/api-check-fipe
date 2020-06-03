using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CheckFipe.Infrastructure.Data.Interfaces
{
    public interface ICheckFipeContext : IDisposable
    {
        DbSet<ConsultaVeiculo> ConsultasVeiculo { get; set; }
        DbSet<Veiculo> Veiculos { get; set; }

        int SaveChanges();
    }
}
