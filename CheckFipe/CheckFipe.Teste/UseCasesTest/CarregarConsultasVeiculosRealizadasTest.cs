using AutoMapper;
using CheckFipe.Application.CarregarConsultasVeiculos;
using CheckFipe.Context;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Infrastructure.Data.Repositories;
using CheckFipe.Models;
using CheckFipe.UseCase;
using NUnit.Framework;
using System;
using System.Linq;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarConsultasVeiculosRealizadasTest
    {
        [TestCase(TipoVeiculo.Carros, 21, 4828, "2013-1", "001267-0", "2013", "Gasolina")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "1995-1", "827001-5", "1995", "Gasolina")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1997-3", "509001-6", "1997", "Diesel")]
        public void ValidarCarregarConsultasVeiculosRealizadas(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string anoEsperado, string combustivelEsperado)
        {
            using var context = new CheckFipeContextTest();
            Veiculo veiculoBuscado = new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();

            var repository = new ConsultaVeiculoRepository(context);
            IMapper mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfig());
            }).CreateMapper();

            var consultas = new CarregarConsultasVeiculosUseCase(repository, mapperConfig).Execute();

            Assert.IsNotNull(consultas);
            Assert.AreEqual(1, consultas.Count());
            Assert.AreEqual(DateTime.Now.Date, consultas.First().DataConsultaVeiculo.Date);
            Assert.AreEqual(veiculoBuscado.Modelo.Marca.Nome, consultas.First().Veiculo.DescricaoMarca);
            Assert.AreEqual(veiculoBuscado.Modelo.Nome, consultas.First().Veiculo.DescricaoModelo);
            Assert.AreEqual(codigoFipeEsperado, consultas.First().Veiculo.CodigoFipe);
            Assert.AreEqual(anoEsperado, consultas.First().Veiculo.AnoModelo);
            Assert.AreEqual(combustivelEsperado, consultas.First().Veiculo.DescricaoCombustivel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(consultas.First().Veiculo.Preco));
        }
    }
}
