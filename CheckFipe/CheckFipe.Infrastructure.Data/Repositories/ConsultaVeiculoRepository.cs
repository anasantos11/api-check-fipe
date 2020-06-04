using CheckFipe.Domain.Entities;
using CheckFipe.Domain.RepositoriesInterfaces;
using CheckFipe.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Infrastructure.Data.Repositories
{
    public class ConsultaVeiculoRepository : IConsultaVeiculoReadOnlyRepository
    {
        private readonly ICheckFipeContext ConsultaVeiculoContext;

        public ConsultaVeiculoRepository(ICheckFipeContext context)
        {
            this.ConsultaVeiculoContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Cadastrar(ConsultaVeiculo objeto)
        {
            this.ConsultaVeiculoContext.ConsultasVeiculo.Add(objeto);
        }

        public IEnumerable<ConsultaVeiculo> Carregar()
        {
            return this.ConsultaVeiculoContext.ConsultasVeiculo
                .Include(consulta => consulta.Veiculo)
                    .ThenInclude(veiculo => veiculo.Modelo)
                        .ThenInclude(modelo => modelo.Marca);

        }
    }
}
