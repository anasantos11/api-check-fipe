using CheckFipe.Domain.Entities;

namespace CheckFipe.Domain.RepositoriesInterfaces
{
    public interface IVeiculoReadOnlyRepository : IReadOnlyRepository<Veiculo>
    {
        Veiculo Carregar(long idModelo, string codigoFipe, string codigoAno);
    }
}
