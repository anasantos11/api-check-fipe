using CheckFipe.Contracts;
using CheckFipe.Entities;
using CheckFipe.Repositories;
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
                .CarregarVeiculos()
                .OrderByDescending(veiculo => veiculo.NumeroDeConsultas)
                .Take(3);
        }
    }
}
