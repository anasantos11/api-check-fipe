using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using System.Collections.Generic;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IAnoService
    {
        IEnumerable<Ano> Carregar(TipoVeiculo tipoVeiculo, string codigoMarca, string codigoModelo);
    }
}
