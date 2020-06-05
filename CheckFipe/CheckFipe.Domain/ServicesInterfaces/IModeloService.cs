using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using System.Collections.Generic;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IModeloService
    {
        IEnumerable<Modelo> Carregar(TipoVeiculo tipoVeiculo, string codigoMarca);
    }
}
