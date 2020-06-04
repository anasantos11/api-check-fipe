using AutoMapper;
using CheckFipe.Domain.RepositoriesInterfaces;
using System.Collections.Generic;

namespace CheckFipe.Application.CarregarConsultasVeiculos
{
    public class CarregarConsultasVeiculosUseCase : ICarregarConsultasVeiculosUseCase
    {
        private readonly IConsultaVeiculoReadOnlyRepository ConsultaVeiculoReadOnlyRepository;
        private readonly IMapper Mapper;
        public CarregarConsultasVeiculosUseCase(IConsultaVeiculoReadOnlyRepository consultaVeiculoReadOnlyRepository, IMapper mapper)
        {
            this.ConsultaVeiculoReadOnlyRepository = consultaVeiculoReadOnlyRepository;
            this.Mapper = mapper;
        }
        public IEnumerable<CarregarConsultasVeiculosOutput> Execute()
        {
            return this.Mapper.Map<IEnumerable<CarregarConsultasVeiculosOutput>>(this.ConsultaVeiculoReadOnlyRepository.Carregar());
        }
    }
}
