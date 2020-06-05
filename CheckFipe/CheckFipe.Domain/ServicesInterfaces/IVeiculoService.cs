using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IVeiculoService
    {
        Veiculo Carregar(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno);
    }
}
