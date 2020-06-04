using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Infraestructure.Proxy.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.ModelsTest
{
    class MarcaTest
    {

        [TestCase(TipoVeiculo.Carros, "JEEP")]
        [TestCase(TipoVeiculo.Motos, "YAMAHA")]
        [TestCase(TipoVeiculo.Caminhoes, "IVECO")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculo tipoVeiculo, string marcaEsperada)
        {

            IEnumerable<Marca> retorno = new MarcaService(tipoVeiculo).Carregar();
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}
