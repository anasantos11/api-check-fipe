using CheckFipe.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CheckFipe.Contracts
{
    public interface ICheckFipeContext : IDisposable
    {
        DbSet<ConsultaVeiculo> ConsultasVeiculo { get; set; }
        DbSet<Veiculo> Veiculos { get; set; }

        int SaveChanges();
    }
}
