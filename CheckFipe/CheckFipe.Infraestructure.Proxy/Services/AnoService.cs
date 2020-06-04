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
        public AnoService(TipoVeiculo tipoVeiculo, string codigoMarca, string codigoModelo) : base(tipoVeiculo, TipoAcaoFipe.Veiculo, codigoMarca, codigoModelo)
        {

        }

        public IEnumerable<Ano> Carregar()
        {
            return Carregar<IEnumerable<FipeBaseOutput>>()
                .Select(retornoFipe => new Ano()
                {
                    CodigoAnoModelo = retornoFipe.Codigo,
                    AnoModelo = retornoFipe.Nome
                })
                .OrderBy(retornoFipe => retornoFipe.AnoModelo);
        }
    }
}
