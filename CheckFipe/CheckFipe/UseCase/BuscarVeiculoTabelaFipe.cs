using CheckFipe.Domain.Enumerators;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Infrastructure.Data.Repositories;
using CheckFipe.Domain.Entities;
using CheckFipe.Infraestructure.Proxy.Services;
using CheckFipe.Domain.RepositoriesInterfaces;

namespace CheckFipe.UseCase
{
    public class BuscarVeiculoTabelaFipe
    {
        public BuscarVeiculoTabelaFipe(ICheckFipeContext context)
        {
            this.Context = context;
        }

        private ICheckFipeContext Context { get; }

        public Veiculo Carregar(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            IVeiculoWriteReadRepository veiculoRepository = new VeiculoRepository(this.Context);
            Veiculo veiculo = veiculoRepository.Carregar(codigoModelo, codigoMarca, codigoAno);

            if (veiculo == null)
            {
                veiculo = new VeiculoService(tipoVeiculo, codigoMarca, codigoModelo, codigoAno).Carregar();
            }

            veiculo.AddConsultaVeiculo();
            veiculoRepository.Registrar(veiculo);

            this.Context.SaveChanges();

            return veiculo;
        }
    }
}
