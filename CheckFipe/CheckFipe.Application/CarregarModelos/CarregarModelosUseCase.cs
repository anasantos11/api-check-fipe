using System.Collections.Generic;
using AutoMapper;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;

namespace CheckFipe.Application.CarregarModelos
{
    public class CarregarModelosUseCase : ICarregarModelosUseCase
    {
        private readonly IModeloService ModeloService;
        private readonly IMapper Mapper;

        public CarregarModelosUseCase(IModeloService modeloService, IMapper mapper)
        {
            this.ModeloService = modeloService;
            this.Mapper = mapper;
        }

        public IEnumerable<CarregarModelosOutput> Execute(TipoVeiculo tipoVeiculo, long codigoMarca)
        {
            return this.Mapper.Map<IEnumerable<CarregarModelosOutput>>(this.ModeloService.Carregar(tipoVeiculo, codigoMarca.ToString()));
        }
    }
}
