using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Application.CarregarVeiculosMaisProcurados
{
    public interface ICarregarVeiculosMaisProcuradosUseCase
    {
        IEnumerable<VeiculoOutput> Execute(int limit);
    }
}
