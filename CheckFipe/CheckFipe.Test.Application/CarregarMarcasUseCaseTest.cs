using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarConsultasVeiculos;
using CheckFipe.Application.CarregarMarcas;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Test.Application
{
    class CarregarMarcasUseCaseTest
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Marca, CarregarMarcasOutput>()
                    .ForMember(marcaOutput => marcaOutput.Codigo, opts => opts.MapFrom(marca => marca.Id));
            }).CreateMapper();
        }

        [TestCase(TipoVeiculo.Carros, "JEEP")]
        [TestCase(TipoVeiculo.Motos, "YAMAHA")]
        [TestCase(TipoVeiculo.Caminhoes, "IVECO")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculo tipoVeiculo, string marcaEsperada)
        {
            //Preparação
            var mockMarcaService = new Mock<IMarcaService>();
            var marcas = new List<Marca>()
            {
                new Marca()
                {
                    Id = 1,
                    Nome = "JEEP"
                },
                new Marca()
                {
                    Id = 2,
                    Nome = "YAMAHA"
                },
                new Marca()
                {
                    Id = 3,
                    Nome = "IVECO"
                }
            };
            mockMarcaService.Setup(config => config.Carregar(tipoVeiculo)).Returns(marcas);

            //Execução
            IEnumerable<CarregarMarcasOutput> retorno = new CarregarMarcasUseCase(mockMarcaService.Object, this.Mapper)
                .Execute(tipoVeiculo);

            //Validação
            Assert.IsTrue(retorno.ToList().Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}
