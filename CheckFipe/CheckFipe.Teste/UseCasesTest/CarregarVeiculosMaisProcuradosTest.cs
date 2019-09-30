using CheckFipe.Context;
using CheckFipe.Entities;
using CheckFipe.Enums;
using CheckFipe.UseCase;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarVeiculosMaisProcuradosTest
    {
        [TestCase(TipoVeiculoFipe.Carros, 21, 4828, "2013-1", "001267-0", "2013", "Gasolina", "R$ 22.371,00")]
        [TestCase(TipoVeiculoFipe.Motos, 101, 3060, "1995-1", "827001-5", "1995", "Gasolina", "R$ 11.099,00")]
        [TestCase(TipoVeiculoFipe.Caminhoes, 109, 3302, "1997-3", "509001-6", "1997", "Diesel", "R$ 45.298,00")]
        public void ValidarCarregarConsultasVeiculosRealizadas(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string anoEsperado, string combustivelEsperado, string precoEsperado)
        {
            using (var context = new CheckFipeContextTest())
            {
                new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
                new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
                new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);

                IEnumerable<Veiculo> veiculosMaisProcurados = new CarregarVeiculosMaisProcurados(context).Carregar();

                Assert.IsNotNull(veiculosMaisProcurados);
                Assert.AreEqual(1, veiculosMaisProcurados.Count());
                Assert.AreEqual(3, veiculosMaisProcurados.First().NumeroDeConsultas);
                Assert.AreEqual(codigoMarca, veiculosMaisProcurados.First().CodigoMarca);
                Assert.AreEqual(codigoFipeEsperado, veiculosMaisProcurados.First().CodigoFipe);
                Assert.AreEqual(codigoAno, veiculosMaisProcurados.First().CodigoAno);
                Assert.AreEqual(anoEsperado, veiculosMaisProcurados.First().AnoModelo);
                Assert.AreEqual(combustivelEsperado, veiculosMaisProcurados.First().DescricaoCombustivel);
                Assert.AreEqual(precoEsperado, veiculosMaisProcurados.First().Preco);
            }
        }
    }
}
