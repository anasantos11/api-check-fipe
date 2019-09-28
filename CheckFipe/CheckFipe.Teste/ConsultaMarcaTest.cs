using CheckFipe.Enums;
using CheckFipe.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CheckFipe.Teste
{
    public class ConsultaMarcaTest
    {
        [TestCase(TipoVeiculoFipe.Carros, "Jeep")]
        [TestCase(TipoVeiculoFipe.Motos, "Yamaha")]
        [TestCase(TipoVeiculoFipe.Caminhoes, "Iveco")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculoFipe tipoVeiculo, string marcaEsperada)
        {
            IEnumerable<RetornoFipe> retorno = new ConsultaMarca(tipoVeiculo).Carregar();
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}
