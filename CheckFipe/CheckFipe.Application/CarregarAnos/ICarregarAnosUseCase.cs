using CheckFipe.Domain.Enumerators;
using System.Collections.Generic;

namespace CheckFipe.Application.CarregarAnos
{
    public interface ICarregarAnosUseCase
    {
        IEnumerable<CarregarAnosOutput> Execute(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo);
    }

}
