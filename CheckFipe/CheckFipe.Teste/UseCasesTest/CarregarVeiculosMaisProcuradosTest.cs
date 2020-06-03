using CheckFipe.Context;
using CheckFipe.Domain.Entities;
using CheckFipe.Enums;
using CheckFipe.UseCase;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarVeiculosMaisProcuradosTest
    {
        [TestCase(TipoVeiculoFipe.Carros, 21, 4828, "2013-1", "001267-0", "2013", "Gasolina")]
        [TestCase(TipoVeiculoFipe.Motos, 101, 3060, "1995-1", "827001-5", "1995", "Gasolina")]
        [TestCase(TipoVeiculoFipe.Caminhoes, 109, 3302, "1997-3", "509001-6", "1997", "Diesel")]
        public void ValidarCarregarConsultasVeiculosRealizadas(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string anoEsperado, string combustivelEsperado)
        {
            using var context = new CheckFipeContextTest();

            new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();
            new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();
            new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
            context.SaveChanges();

            IEnumerable<Veiculo> veiculosMaisProcurados = new CarregarVeiculosMaisProcurados(context).Carregar();

            Assert.IsNotNull(veiculosMaisProcurados);
            Assert.AreEqual(1, veiculosMaisProcurados.Count());
            Assert.AreEqual(3, veiculosMaisProcurados.First().NumeroDeConsultas);
            Assert.AreEqual(codigoMarca, veiculosMaisProcurados.First().Modelo.IdMarca);
            Assert.AreEqual(codigoFipeEsperado, veiculosMaisProcurados.First().CodigoFipe);
            Assert.AreEqual(codigoAno, veiculosMaisProcurados.First().CodigoAnoModelo);
            Assert.AreEqual(anoEsperado, veiculosMaisProcurados.First().AnoModelo);
            Assert.AreEqual(combustivelEsperado, veiculosMaisProcurados.First().DescricaoCombustivel);
            Assert.IsFalse(string.IsNullOrWhiteSpace(veiculosMaisProcurados.First().Preco));
        }
    }
}
