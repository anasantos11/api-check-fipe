using System;
using System.Collections.Generic;
using System.Linq;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Interfaces;
using CheckFipe.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckFipe.Infrastructure.Data.Repositories
{
    public class VeiculoRepository : IRepository<Veiculo>
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

        public IEnumerable<Veiculo> Carregar()
        {
            return this.VeiculoContext.Veiculos
                .Include(veiculo => veiculo.ConsultasVeiculo);
        }
    }
}
