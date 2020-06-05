using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using NUnit.Framework;
using CheckFipe.Application.BuscarVeiculo;
using AutoMapper;
using CheckFipe.Application;
using Moq;
using CheckFipe.Domain.ServicesInterfaces;
using CheckFipe.Domain.RepositoriesInterfaces;

namespace CheckFipe.Teste.UseCaseTest
{
    public class BuscarVeiculoUseCaseTest
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Veiculo, VeiculoOutput>()
                    .ForMember(veiculoOutput => veiculoOutput.DescricaoMarca, opts => opts.MapFrom(veiculo => veiculo.Modelo.Marca.Nome))
                    .ForMember(veiculoOutput => veiculoOutput.DescricaoModelo, opts => opts.MapFrom(veiculo => veiculo.Modelo.Nome));
            }).CreateMapper();
        }

        [Test]
        public void ValidarBuscarVeiculo()
        {
            //Preparação
            var mockVeiculoService = new Mock<IVeiculoService>();
            var mockRepository = new Mock<IVeiculoWriteReadRepository>();

            var veiculo = new Veiculo()
            {
                Id = 1,
                CodigoAnoModelo = "2013-1",
                CodigoFipe = "001267-0",
                DescricaoCombustivel = "Gasolina",
                AnoModelo = "2013",
                Preco = "R$ 11.755,00",
                IdModelo = 4828,
                Modelo = new Modelo()
                {
                    Id = 4828,
                    Nome = "Palio 1.0 ECONOMY Fire Flex 8V 4p",
                    IdMarca = 21,
                    Marca = new Marca()
                    {
                        Id = 21,
                        Nome = "Fiat",
                    }
                }
            };
            mockVeiculoService.Setup(config => config.Carregar(TipoVeiculo.Carros, 21, 4828, "2013-1")).Returns(veiculo);

            //Execução
            VeiculoOutput veiculoBuscado = new BuscarVeiculoUseCase(mockVeiculoService.Object, mockRepository.Object, this.Mapper)
                .Execute(TipoVeiculo.Carros, 21, 4828, "2013-1");

            Assert.IsNotNull(veiculoBuscado);
            Assert.AreEqual("Fiat", veiculoBuscado.DescricaoMarca);
            Assert.AreEqual("Palio 1.0 ECONOMY Fire Flex 8V 4p", veiculoBuscado.DescricaoModelo);
            Assert.AreEqual("001267-0", veiculoBuscado.CodigoFipe);
            Assert.AreEqual("2013", veiculoBuscado.AnoModelo);
            Assert.AreEqual("Gasolina", veiculoBuscado.DescricaoCombustivel);
            //TODO Colocar MesReferencia no veículo Assert.IsNotNull(veiculoBuscado.MesReferencia);
            Assert.AreEqual("R$ 11.755,00", veiculoBuscado.Preco);
        }
    }
}
