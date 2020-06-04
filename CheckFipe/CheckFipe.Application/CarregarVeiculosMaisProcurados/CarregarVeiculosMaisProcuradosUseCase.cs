using AutoMapper;
using CheckFipe.Domain.RepositoriesInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Application.CarregarVeiculosMaisProcurados
{
    public class CarregarVeiculosMaisProcuradosUseCase : ICarregarVeiculosMaisProcuradosUseCase
    {
        private readonly IVeiculoReadOnlyRepository VeiculoReadOnlyRepository;
        private readonly IMapper Mapper;

        public CarregarVeiculosMaisProcuradosUseCase(IVeiculoReadOnlyRepository veiculoReadOnlyRepository, IMapper mapper)
        {
            this.VeiculoReadOnlyRepository = veiculoReadOnlyRepository;
            this.Mapper = mapper;
        }
        public IEnumerable<VeiculoOutput> Execute(int limit)
        {
            return this.Mapper
                .Map<IEnumerable<VeiculoOutput>>(this.VeiculoReadOnlyRepository.Carregar())
                .OrderByDescending(veiculo => veiculo.NumeroDeConsultas)
                .Take(limit);
        }
    }
}
