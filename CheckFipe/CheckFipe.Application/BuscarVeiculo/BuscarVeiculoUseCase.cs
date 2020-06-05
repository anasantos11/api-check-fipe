using AutoMapper;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;

namespace CheckFipe.Application.BuscarVeiculo
{
    public class BuscarVeiculoUseCase : IBuscarVeiculoUseCase
    {
        private readonly IVeiculoService VeiculoService;
        private readonly IMapper Mapper;
        public BuscarVeiculoUseCase(IVeiculoService veiculoService, IMapper mapper)
        {
            this.VeiculoService = veiculoService;
            this.Mapper = mapper;
        }

        public VeiculoOutput Carregar(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            return this.Mapper.Map<VeiculoOutput>(this.VeiculoService.Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno));
        }
    }
}
