using CheckFipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Domain.ServicesInterfaces
{
    public interface IVeiculoService
    {
        Veiculo Carregar();
    }
}
