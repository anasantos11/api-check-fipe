using CheckFipe.Domain.Entities;
using System.Collections.Generic;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IAnoService
    {
        IEnumerable<Ano> Carregar();
    }
}
