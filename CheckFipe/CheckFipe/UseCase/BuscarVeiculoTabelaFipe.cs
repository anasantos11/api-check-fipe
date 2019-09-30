using CheckFipe.Contracts;
using CheckFipe.Enums;
using CheckFipe.Models;
using CheckFipe.Repositories;

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

            new ConsultaVeiculoRepository(this.Context).CadastrarConsultaVeiculo(codigoMarca, codigoAno, retornoFipe);

            return retornoFipe;
        }
    }
}
