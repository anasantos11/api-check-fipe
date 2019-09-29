using CheckFipe.Enums;
using CheckFipe.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckFipe.Teste.ModelsTest
{
    public class ModeloTest
    {
        [TestCase(TipoVeiculoFipe.Carros, 21, 4828, "Palio 1.0 ECONOMY Fire Flex 8V 4p")]
        [TestCase(TipoVeiculoFipe.Motos, 101, 3060, "750 VIRAGO")]
        [TestCase(TipoVeiculoFipe.Caminhoes, 109, 3302, "1114 3-Eixos 2p (diesel)")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModeloEsperado, string nomeModeloEsperado)
        {

            IEnumerable<Modelo> retorno = Modelo.Carregar(tipoVeiculo, codigoMarca);
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Codigo == codigoModeloEsperado && marca.Nome == nomeModeloEsperado) > 0);
        }
    }
}
