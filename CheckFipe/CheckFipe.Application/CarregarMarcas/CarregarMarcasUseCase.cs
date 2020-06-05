using System.Collections.Generic;
using AutoMapper;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;

namespace CheckFipe.Application.CarregarMarcas
{
    public class CarregarMarcasUseCase : ICarregarMarcasUseCase
    {
        private readonly IMarcaService MarcaService;
        private readonly IMapper Mapper;
        public CarregarMarcasUseCase(IMarcaService marcaService, IMapper mapper)
        {
            this.MarcaService = marcaService;
            this.Mapper = mapper;
        }
        public IEnumerable<CarregarMarcasOutput> Execute(TipoVeiculo tipoVeiculo)
        {
            return this.Mapper.Map<IEnumerable<CarregarMarcasOutput>>(this.MarcaService.Carregar(tipoVeiculo));
        }
    }
}
