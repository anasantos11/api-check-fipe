using CheckFipe.Enums;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Models;
using CheckFipe.Infrastructure.Data.Repositories;
using CheckFipe.Domain.Entities;

namespace CheckFipe.UseCase
{
    public class BuscarVeiculoTabelaFipe
    {
        public BuscarVeiculoTabelaFipe(ICheckFipeContext context)
        {
            this.Context = context;
        }

        private ICheckFipeContext Context { get; }

        public VeiculoRetornoFipe Carregar(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            VeiculoRetornoFipe retornoFipe = new ConsultaFipe(tipoVeiculo, AcaoFipe.Veiculo, codigoMarca.ToString(), codigoModelo.ToString(), codigoAno)
                .Carregar<VeiculoRetornoFipe>();

            var veiculoRepository = new VeiculoRepository(this.Context);
            Veiculo veiculo = veiculoRepository.Carregar(codigoMarca, retornoFipe.CodigoFipe, codigoAno);

            if (veiculo == null)
            {
                veiculo = new Veiculo(codigoMarca, retornoFipe.CodigoFipe, codigoAno, retornoFipe.AnoModelo, retornoFipe.DescricaoCombustivel,
                    retornoFipe.Preco, retornoFipe.DescricaoMarca, retornoFipe.DescricaoModelo);
                veiculo.AddConsultaVeiculo();
                veiculoRepository.Cadastrar(veiculo);
            } else
            {
                veiculo.AddConsultaVeiculo();
                veiculoRepository.Atualizar(veiculo);
            }


            return retornoFipe;
        }
    }
}
