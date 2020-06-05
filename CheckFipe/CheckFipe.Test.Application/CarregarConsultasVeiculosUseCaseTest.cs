using AutoMapper;
using CheckFipe.Application.CarregarConsultasVeiculos;
using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using CheckFipe.Application;
using CheckFipe.Infrastructure.Data.Contexts;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarConsultasVeiculosUseCaseTest
    {
        private IMapper Mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<ConsultaVeiculo, CarregarConsultasVeiculosOutput>();
                config.CreateMap<Veiculo, VeiculoOutput>()
                    .ForMember(veiculoOutput => veiculoOutput.DescricaoMarca, opts => opts.MapFrom(veiculo => veiculo.Modelo.Marca.Nome))
                    .ForMember(veiculoOutput => veiculoOutput.DescricaoModelo, opts => opts.MapFrom(veiculo => veiculo.Modelo.Nome));
            }).CreateMapper();
        }

        [Test]
        public void ValidarCarregarConsultasVeiculosRealizadas()
        {
            var mockContext = new Mock<CheckFipeContext>();
            
            var dados = new List<ConsultaVeiculo>()
            {
                new ConsultaVeiculo()
                {
                    Id = 1,
                    DataConsultaVeiculo = DateTime.Now,
                    IdVeiculo = 1,
                    Veiculo = new Veiculo()
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
                        }
                    }
                }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<ConsultaVeiculo>>();
            mockSet.As<IQueryable<ConsultaVeiculo>>().Setup(config => config.Provider).Returns(dados.Provider);
            mockSet.As<IQueryable<ConsultaVeiculo>>().Setup(config => config.Expression).Returns(dados.Expression);
            mockSet.As<IQueryable<ConsultaVeiculo>>().Setup(config => config.ElementType).Returns(dados.ElementType);
            mockSet.As<IQueryable<ConsultaVeiculo>>().Setup(config => config.GetEnumerator()).Returns(dados.GetEnumerator());
            mockContext.Setup(config => config.ConsultasVeiculo).Returns(mockSet.Object);
            var mockRepository = new ConsultaVeiculoRepository(mockContext.Object);

            var consultas = new CarregarConsultasVeiculosUseCase(mockRepository, this.Mapper).Execute().ToList();

            Assert.IsNotNull(consultas);
            Assert.AreEqual(1, consultas.Count());
            Assert.AreEqual(DateTime.Now.Date, consultas.First().DataConsultaVeiculo.Date);
            Assert.AreEqual("Fiat", consultas.First().Veiculo.DescricaoMarca);
            Assert.AreEqual("Palio 1.0 ECONOMY Fire Flex 8V 4p", consultas.First().Veiculo.DescricaoModelo);
            Assert.AreEqual("001267-0", consultas.First().Veiculo.CodigoFipe);
            Assert.AreEqual("2013", consultas.First().Veiculo.AnoModelo);
            Assert.AreEqual("Gasolina", consultas.First().Veiculo.DescricaoCombustivel);
            Assert.AreEqual("R$ 22.000,00", consultas.First().Veiculo.Preco);
        }
    }
}
