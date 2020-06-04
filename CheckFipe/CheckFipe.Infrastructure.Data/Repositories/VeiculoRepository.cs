using System;
using System.Collections.Generic;
using System.Linq;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.RepositoriesInterfaces;
using CheckFipe.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckFipe.Infrastructure.Data.Repositories
{
    public class VeiculoRepository : IVeiculoWriteOnlyRepository, IVeiculoReadOnlyRepository
    {
        private readonly ICheckFipeContext VeiculoContext;

        public VeiculoRepository(ICheckFipeContext context)
        {
            this.VeiculoContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Cadastrar(Veiculo objeto)
        {
            this.VeiculoContext.Veiculos.Add(objeto);
        }

        public void Atualizar(Veiculo objeto)
        {
            this.VeiculoContext.Entry(objeto).State = EntityState.Modified;
        }

        public IEnumerable<Veiculo> Carregar()
        {
            return this.VeiculoContext.Veiculos
                .Include(veiculo => veiculo.ConsultasVeiculo)
                .Include(veiculo => veiculo.Modelo)
                    .ThenInclude(modelo => modelo.Marca);
        }

        public Veiculo Carregar(long idModelo, string codigoFipe, string codigoAno)
        {
            return this.VeiculoContext.Veiculos
                .Include(veiculo => veiculo.ConsultasVeiculo)
                .Include(veiculo => veiculo.Modelo)
                    .ThenInclude(modelo => modelo.Marca)
                .Where(veiculo => veiculo.IdModelo == idModelo && veiculo.CodigoFipe == codigoFipe && veiculo.CodigoAnoModelo == codigoAno)
                .FirstOrDefault();
        }

    }
}
