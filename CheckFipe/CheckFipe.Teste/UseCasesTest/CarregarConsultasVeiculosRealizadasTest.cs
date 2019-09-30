using CheckFipe.Context;
using CheckFipe.Enums;
using CheckFipe.Teste.Models;
using CheckFipe.UseCase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckFipe.Teste.UseCasesTest
{
    public class CarregarConsultasVeiculosRealizadasTest
    {
        [TestCase(TipoVeiculoFipe.Carros, 21, 4828, "2013-1", "001267-0", "2013", "Gasolina", "R$ 22.371,00")]
        [TestCase(TipoVeiculoFipe.Motos, 101, 3060, "1995-1", "827001-5", "1995", "Gasolina", "R$ 11.099,00")]
        [TestCase(TipoVeiculoFipe.Caminhoes, 109, 3302, "1997-3", "509001-6", "1997", "Diesel", "R$ 45.298,00")]
        public void ValidarCarregarConsultasVeiculosRealizadas(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string anoEsperado, string combustivelEsperado, string precoEsperado)
        {
            using (var context = new CheckFipeContextTest())
            {
                VeiculoRetornoFipe veiculoBuscado = new BuscarVeiculoTabelaFipe(context).Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);
                var consultas = new CarregarConsultasVeiculosRealizadas(context).Carregar();
                Assert.IsNotNull(consultas);
                Assert.AreEqual(1, consultas.Count());
                Assert.AreEqual(DateTime.Now.Date, consultas.First().DataConsultaVeiculo.Date);
                Assert.AreEqual(codigoMarca, consultas.First().Veiculo.CodigoMarca);
                Assert.AreEqual(codigoFipeEsperado, consultas.First().Veiculo.CodigoFipe);
                Assert.AreEqual(codigoAno, consultas.First().Veiculo.CodigoAno);
                Assert.AreEqual(anoEsperado, consultas.First().Veiculo.AnoModelo);
                Assert.AreEqual(combustivelEsperado, consultas.First().Veiculo.DescricaoCombustivel);
                Assert.AreEqual(precoEsperado, consultas.First().Veiculo.Preco);
            }
        }
    }
}
