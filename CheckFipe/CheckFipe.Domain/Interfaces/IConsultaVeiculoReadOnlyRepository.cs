using CheckFipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Domain.Interfaces
{
    public interface IConsultaVeiculoReadOnlyRepository
    {
        IEnumerable<ConsultaVeiculo> Carregar();
    }
}
