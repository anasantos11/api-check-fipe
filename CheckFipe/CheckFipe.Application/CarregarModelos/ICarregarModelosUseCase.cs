using CheckFipe.Domain.Enumerators;
using System.Collections.Generic;

namespace CheckFipe.Application.CarregarModelos
{
    public interface ICarregarModelosUseCase
    {
        IEnumerable<CarregarModelosOutput> Execute(TipoVeiculo tipoVeiculo, long codigoMarca);
    }
}
