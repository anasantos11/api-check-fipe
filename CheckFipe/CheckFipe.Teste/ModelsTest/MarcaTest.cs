using CheckFipe.Enums;
using CheckFipe.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.ModelsTest
{
    class MarcaTest
    {

        [TestCase(TipoVeiculoFipe.Carros, "JEEP")]
        [TestCase(TipoVeiculoFipe.Motos, "YAMAHA")]
        [TestCase(TipoVeiculoFipe.Caminhoes, "IVECO")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculoFipe tipoVeiculo, string marcaEsperada)
        {

            IEnumerable<Marca> retorno = Marca.Carregar(tipoVeiculo);
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}
