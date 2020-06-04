using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFipe.Application.CarregarConsultasVeiculos
{
    public interface ICarregarConsultasVeiculosUseCase
    {
        IEnumerable<CarregarConsultasVeiculosOutput> Execute();
    }
}
