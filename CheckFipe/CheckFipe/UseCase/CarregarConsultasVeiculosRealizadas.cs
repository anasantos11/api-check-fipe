using CheckFipe.Contracts;
using CheckFipe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.UseCase
{
    public class CarregarConsultasVeiculosRealizadas
    {
        public CarregarConsultasVeiculosRealizadas(ICheckFipeContext context)
        {
            this.Context = context;
        }
        private ICheckFipeContext Context { get; }

        public IEnumerable<CheckFipe.Entities.ConsultaVeiculo> Carregar()
        {
            return new ConsultaVeiculoRepository(this.Context).CarregarConsultasVeiculos();
        }
    }
}
