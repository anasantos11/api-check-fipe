using CheckFipe.Domain.Enumerators;
using System.Collections.Generic;

namespace CheckFipe.Application.CarregarMarcas
{
    public interface ICarregarMarcasUseCase
    {
        IEnumerable<CarregarMarcasOutput> Execute(TipoVeiculo tipoVeiculo);
    }
}
