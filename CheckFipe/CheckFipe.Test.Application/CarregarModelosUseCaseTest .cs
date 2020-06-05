using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarConsultasVeiculos;
using CheckFipe.Application.CarregarMarcas;
using CheckFipe.Application.CarregarModelos;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Domain.ServicesInterfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Test.Application
{
    class CarregarModelosUseCaseTest
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Modelo, CarregarModelosOutput>()
                 .ForMember(modeloOutput => modeloOutput.Codigo, opts => opts.MapFrom(modelo => modelo.Id));
            }).CreateMapper();
        }

        [TestCase(TipoVeiculo.Carros, 21, 4828, "Palio 1.0 ECONOMY Fire Flex 8V 4p")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "750 VIRAGO")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1114 3-Eixos 2p (diesel)")]
        public void ValidarCarregamentoDosModelos(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModeloEsperado, string nomeModeloEsperado)
        {
            //Preparação
            var mockModeloService = new Mock<IModeloService>();
            var modelos = new List<Modelo>()
            {
                new Modelo()
                {
                    Id = 4828,
                    Nome = "Palio 1.0 ECONOMY Fire Flex 8V 4p",
                    Marca = new Marca()
                    {
                        Id = 21,
                        Nome = "FIAT"
                    }
                },
                new Modelo()
                {        
                    Id = 3060,
                    Nome = "750 VIRAGO",
                    Marca = new Marca()
                    {
                        Id = 101,
                        Nome = "YAMAHA"
                    }
                },
                new Modelo()
                {
                    Id = 3302,
                    Nome = "1114 3-Eixos 2p (diesel)",
                    Marca = new Marca()
                    {
                        Id = 109,
                        Nome = "MERCEDES-BENZ"
                    }
                }
            };
            mockModeloService.Setup(config => config.Carregar(tipoVeiculo, codigoMarca.ToString())).Returns(modelos);

            //Execução
            IEnumerable<CarregarModelosOutput> retorno = new CarregarModelosUseCase(mockModeloService.Object, this.Mapper)
                .Execute(tipoVeiculo, codigoMarca);

            //Validação
            Assert.IsTrue(retorno.Count(modelo => modelo.Codigo == codigoModeloEsperado && modelo.Nome == nomeModeloEsperado) > 0);
        }
    }
}
