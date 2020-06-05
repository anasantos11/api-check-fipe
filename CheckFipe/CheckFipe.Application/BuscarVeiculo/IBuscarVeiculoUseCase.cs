using CheckFipe.Domain.Enumerators;

namespace CheckFipe.Application.BuscarVeiculo
{
    public interface IBuscarVeiculoUseCase
    {
        VeiculoOutput Carregar(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno);
    }
}
