using CheckFipe.Domain.Entities;
using System.Collections.Generic;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IModeloService
    {
        IEnumerable<Modelo> Carregar();
    }
}
