using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using System.Collections.Generic;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IMarcaService
    {
        IEnumerable<Marca> Carregar(TipoVeiculo tipoVeiculo);
    }
}
