using CheckFipe.Domain.Enumerators;

namespace CheckFipe.Application.BuscarVeiculo
{
    public interface IBuscarVeiculoUseCase
    {
        VeiculoOutput Execute(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno);
    }
}
