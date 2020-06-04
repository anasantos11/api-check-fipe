using CheckFipe.Domain.Entities;

namespace CheckFipe.Domain.RepositoriesInterfaces
{
    public interface IVeiculoReadOnlyRepository : IReadOnlyRepository<Veiculo>
    {
        Veiculo Carregar(long idModelo, long idMarca, string codigoAno);
    }
}
