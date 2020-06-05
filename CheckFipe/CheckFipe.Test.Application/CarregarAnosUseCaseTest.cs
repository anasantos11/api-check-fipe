using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarAnos;
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
    class CarregarAnosUseCaseTest
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Ano, CarregarAnosOutput>()
                    .ForMember(anoOutput => anoOutput.Codigo, opts => opts.MapFrom(ano => ano.CodigoAnoModelo))
                    .ForMember(anoOutput => anoOutput.Nome, opts => opts.MapFrom(ano => ano.AnoModelo));
            }).CreateMapper();
        }

        [TestCase(TipoVeiculo.Carros, 21, 4828, "2013-1", "2013 Gasolina")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "1995-1", "1995")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1997-3", "1997")]
        public void ValidarCarregamentoDosAnos(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAnoEsperado, string descricaoAnoEsperado)
        {
            //Preparação
            var mockAnoService = new Mock<IAnoService>();
            var anos = new List<Ano>()
            {
                new Ano()
                {
                    CodigoAnoModelo = "2013-1",
                    AnoModelo = "2013 Gasolina"
                },
                new Ano()
                {
                    CodigoAnoModelo = "1995-1",
                    AnoModelo = "1995"
                },
                new Ano()
                {
                    CodigoAnoModelo = "1997-3",
                    AnoModelo = "1997"
                }
            };
            mockAnoService.Setup(config => config.Carregar(tipoVeiculo, codigoMarca.ToString(), codigoModelo.ToString())).Returns(anos);

            //Execução
            IEnumerable<CarregarAnosOutput> retorno = new CarregarAnosUseCase(mockAnoService.Object, this.Mapper)
                .Execute(tipoVeiculo, codigoMarca, codigoModelo);

            //Validação
            Assert.IsTrue(retorno.Count(ano => ano.Codigo == codigoAnoEsperado && ano.Nome == descricaoAnoEsperado) > 0);
        }
    }
}
