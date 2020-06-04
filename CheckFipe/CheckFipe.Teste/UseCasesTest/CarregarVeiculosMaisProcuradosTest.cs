using AutoMapper;
using CheckFipe.Application;
using CheckFipe.Application.CarregarVeiculosMaisProcurados;
using CheckFipe.Context;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Infrastructure.Data.Repositories;
using CheckFipe.UseCase;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarVeiculosMaisProcuradosTest
    {
        [TestCase(TipoVeiculo.Carros, 21, 4828, "2013-1", "001267-0", "2013", "Gasolina")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "1995-1", "827001-5", "1995", "Gasolina")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1997-3", "509001-6", "1997", "Diesel")]
        public void ValidarCarregarConsultasVeiculosRealizadas(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string anoEsperado, string combustivelEsperado)
        {
            using var context = new CheckFipeContextTest();

            var retornoFipe = new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();
            new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();
            new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();

            var repository = new VeiculoRepository(context);
            IMapper mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfig());
            }).CreateMapper();

            IEnumerable<VeiculoOutput> veiculosMaisProcurados = new CarregarVeiculosMaisProcuradosUseCase(repository, mapperConfig).Execute(3);

            Assert.IsNotNull(veiculosMaisProcurados);
            Assert.AreEqual(1, veiculosMaisProcurados.Count());
            Assert.AreEqual(3, veiculosMaisProcurados.First().NumeroDeConsultas);
            Assert.AreEqual(retornoFipe.Modelo.Marca.Nome, veiculosMaisProcurados.First().DescricaoMarca);
            Assert.AreEqual(retornoFipe.Modelo.Nome, veiculosMaisProcurados.First().DescricaoModelo);
            Assert.AreEqual(codigoFipeEsperado, veiculosMaisProcurados.First().CodigoFipe);
            Assert.AreEqual(anoEsperado, veiculosMaisProcurados.First().AnoModelo);
            Assert.AreEqual(combustivelEsperado, veiculosMaisProcurados.First().DescricaoCombustivel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(veiculosMaisProcurados.First().Preco));
        }
    }
}
