using AutoMapper;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.RepositoriesInterfaces;
using CheckFipe.Domain.ServicesInterfaces;

namespace CheckFipe.Application.BuscarVeiculo
{
    public class BuscarVeiculoUseCase : IBuscarVeiculoUseCase
    {
        private readonly IVeiculoService VeiculoService;
        private readonly IVeiculoWriteReadRepository VeiculoRepository;
        private readonly IMapper Mapper;

        public BuscarVeiculoUseCase(IVeiculoService veiculoService, IVeiculoWriteReadRepository veiculoRepository, IMapper mapper)
        {
            this.VeiculoService = veiculoService;
            this.VeiculoRepository = veiculoRepository;
            this.Mapper = mapper;
        }

        public VeiculoOutput Execute(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            Veiculo veiculo = this.VeiculoRepository.Carregar(codigoModelo, codigoMarca, codigoAno);

            if (veiculo == null)
            {
                veiculo = this.VeiculoService.Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            }

            veiculo.AddConsultaVeiculo();
            this.VeiculoRepository.Registrar(veiculo);

            return this.Mapper.Map<VeiculoOutput>(this.VeiculoService.Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno));
        }
    }
}
