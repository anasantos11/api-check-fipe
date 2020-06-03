using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace CheckFipe.Infrastructure.Data.Interfaces
{
    public interface ICheckFipeContext : IDisposable
    {
        DbSet<ConsultaVeiculo> ConsultasVeiculo { get; set; }
        DbSet<Veiculo> Veiculos { get; set; }

        int SaveChanges();

        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
    }
}
