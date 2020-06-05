using System.Collections.Generic;
using AutoMapper;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;

namespace CheckFipe.Application.CarregarAnos
{
    public class CarregarAnosUseCase : ICarregarAnosUseCase
    {
        private readonly IAnoService AnoService;
        private readonly IMapper Mapper;
        public CarregarAnosUseCase(IAnoService anoService, IMapper mapper)
        {
            this.AnoService = anoService;
            this.Mapper = mapper;
        }

        public IEnumerable<CarregarAnosOutput> Execute(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo)
        {
            return this.Mapper.Map<IEnumerable<CarregarAnosOutput>>(this.AnoService.Carregar(tipoVeiculo, codigoMarca.ToString(), codigoModelo.ToString()));
        }
    }
}
