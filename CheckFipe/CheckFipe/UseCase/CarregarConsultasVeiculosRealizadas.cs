using CheckFipe.Contracts;
using CheckFipe.Entities;
using CheckFipe.Repositories;
using System.Collections.Generic;

namespace CheckFipe.UseCase
{
    public class CarregarConsultasVeiculosRealizadas
    {
        public CarregarConsultasVeiculosRealizadas(ICheckFipeContext context)
        {
            this.Context = context;
        }
        private ICheckFipeContext Context { get; }

        public IEnumerable<ConsultaVeiculo> Carregar()
        {
            return new ConsultaVeiculoRepository(this.Context).CarregarConsultasVeiculos();
        }
    }
}
