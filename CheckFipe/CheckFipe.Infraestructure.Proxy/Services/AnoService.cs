using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;
using CheckFipe.Infraestructure.Proxy.DataTransferObjects;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Infraestructure.Proxy.Services
{
    public class AnoService : FipeBaseService, IAnoService
    {
        public IEnumerable<Ano> Carregar(TipoVeiculo tipoVeiculo, string codigoMarca, string codigoModelo)
        {
            return Carregar<IEnumerable<FipeBaseOutput>>(tipoVeiculo, TipoAcaoFipe.Veiculo, codigoMarca, codigoModelo)
                .Select(retornoFipe => new Ano()
                {
                    CodigoAnoModelo = retornoFipe.Codigo,
                    AnoModelo = retornoFipe.Nome
                })
                .OrderBy(retornoFipe => retornoFipe.AnoModelo);
        }
    }
}
