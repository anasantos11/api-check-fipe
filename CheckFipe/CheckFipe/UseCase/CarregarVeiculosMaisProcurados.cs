using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Infrastructure.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.UseCase
{
    public class CarregarVeiculosMaisProcurados
    {
        public CarregarVeiculosMaisProcurados(ICheckFipeContext context)
        {
            this.Context = context;
        }
        private ICheckFipeContext Context { get; }

        public IEnumerable<Veiculo> Carregar()
        {
            return new VeiculoRepository(this.Context)
                .Carregar()
                .OrderByDescending(veiculo => veiculo.NumeroDeConsultas)
                .Take(3);
        }
    }
}
