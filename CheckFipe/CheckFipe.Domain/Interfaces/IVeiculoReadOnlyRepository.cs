using CheckFipe.Domain.Entities;

namespace CheckFipe.Domain.Interfaces
{
    public interface IVeiculoReadOnlyRepository : IReadOnlyRepository<Veiculo>
    {
        Veiculo Carregar(long idModelo, string codigoFipe, string codigoAno);
    }
}
