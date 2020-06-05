using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarVeiculosMaisProcurados;
using CheckFipe.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using CheckFipe.Infraestructure.Proxy.Services;
using CheckFipe.Infrastructure.Data.Contexts;
using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarVeiculosMaisProcuradosUseCaseTest
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
        public void ValidarCarregarConsultasVeiculosRealizadas()
        {
            var mockContext = new Mock<CheckFipeContext>();

            var dados = new List<Veiculo>()
            {
                new Veiculo()
                {
                    Id = 1,
                    CodigoFipe = "001267-0",
                    CodigoAnoModelo = "2013-1",
                    AnoModelo = "2013",
                    DescricaoCombustivel = "Gasolina",
                    Preco = "R$ 22.000,00",
                    IdModelo = 4828,
                    Modelo = new Modelo()
                    {
                        Id = 4828,
                        Nome = "Palio 1.0 ECONOMY Fire Flex 8V 4p",
                        IdMarca = 21,
                        Marca = new Marca(){
                            Id = 21,
                            Nome = "Fiat"
                        }
                    },
                    ConsultasVeiculo = new List<ConsultaVeiculo>()
                    {
                        new ConsultaVeiculo()
                        {
                            Id = 1,
                            DataConsultaVeiculo = DateTime.Now
                        }
                    }
                },
                new Veiculo()
                {
                    Id = 2,
                    CodigoFipe = "827001-5",
                    CodigoAnoModelo = "1995-1",
                    AnoModelo = "1995",
                    DescricaoCombustivel = "Gasolina",
                    Preco = "R$ 11.755,00",
                    IdModelo = 3060,
                    Modelo = new Modelo()
                    {
                        Id = 3060,
                        Nome = "750 VIRAGO",
                        IdMarca = 109,
                        Marca = new Marca(){
                            Id = 109,
                            Nome = "YAMAHA"
                        }
                    },
                    ConsultasVeiculo = new List<ConsultaVeiculo>()
                    {
                        new ConsultaVeiculo()
                        {
                            Id = 1,
                            DataConsultaVeiculo = DateTime.Now.AddDays(-1)
                        },
                        new ConsultaVeiculo()
                        {
                            Id = 2,
                            DataConsultaVeiculo = DateTime.Now
                        }
                    }
                }

            }.AsQueryable();
            var mockSet = new Mock<DbSet<Veiculo>>();
            mockSet.As<IQueryable<Veiculo>>().Setup(config => config.Provider).Returns(dados.Provider);
            mockSet.As<IQueryable<Veiculo>>().Setup(config => config.Expression).Returns(dados.Expression);
            mockSet.As<IQueryable<Veiculo>>().Setup(config => config.ElementType).Returns(dados.ElementType);
            mockSet.As<IQueryable<Veiculo>>().Setup(config => config.GetEnumerator()).Returns(dados.GetEnumerator());
            mockContext.Setup(config => config.Veiculos).Returns(mockSet.Object);
            
            var veiculoRepository = new VeiculoRepository(mockContext.Object);

            IEnumerable<VeiculoOutput> veiculosMaisProcurados = new CarregarVeiculosMaisProcuradosUseCase(veiculoRepository, this.Mapper).Execute(3);

            Assert.IsNotNull(veiculosMaisProcurados);
            Assert.AreEqual(2, veiculosMaisProcurados.Count());
            Assert.AreEqual(2, veiculosMaisProcurados.First().NumeroDeConsultas);
            Assert.AreEqual("YAMAHA", veiculosMaisProcurados.First().DescricaoMarca);
            Assert.AreEqual("750 VIRAGO", veiculosMaisProcurados.First().DescricaoModelo);
            Assert.AreEqual("827001-5", veiculosMaisProcurados.First().CodigoFipe);
            Assert.AreEqual("1995", veiculosMaisProcurados.First().AnoModelo);
            Assert.AreEqual("Gasolina", veiculosMaisProcurados.First().DescricaoCombustivel);
            Assert.AreEqual("R$ 11.755,00", veiculosMaisProcurados.First().Preco);
        }
    }
}
