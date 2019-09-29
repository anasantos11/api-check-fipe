using CheckFipe.Enums;
using CheckFipe.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CheckFipe.Teste
{
    public class Tests
    {

        [TestCase(TipoVeiculoFipe.Carros, AcaoFipe.Marcas, ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/marcas.json")]
        [TestCase(TipoVeiculoFipe.Motos, AcaoFipe.Marcas, ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/marcas.json")]
        [TestCase(TipoVeiculoFipe.Caminhoes, AcaoFipe.Marcas, ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/marcas.json")]
        [TestCase(TipoVeiculoFipe.Carros, AcaoFipe.Veiculos, "21", ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/veiculos/21.json")]
        [TestCase(TipoVeiculoFipe.Motos, AcaoFipe.Veiculos, "101", ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/veiculos/101.json")]
        [TestCase(TipoVeiculoFipe.Caminhoes, AcaoFipe.Veiculos, "109", ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/veiculos/109.json")]
        [TestCase(TipoVeiculoFipe.Carros, AcaoFipe.Veiculo, "21", "4828", ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/veiculo/21/4828.json")]
        [TestCase(TipoVeiculoFipe.Motos, AcaoFipe.Veiculo, "101", "3060", ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/veiculo/101/3060.json")]
        [TestCase(TipoVeiculoFipe.Caminhoes, AcaoFipe.Veiculo, "109", "3302", ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/veiculo/109/3302.json")]
        [TestCase(TipoVeiculoFipe.Carros, AcaoFipe.Veiculo, "21", "4828", "2013-01", ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/veiculo/21/4828/2013-01.json")]
        [TestCase(TipoVeiculoFipe.Motos, AcaoFipe.Veiculo, "101", "3060", "1995-1", ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/veiculo/101/3060/1995-1.json")]
        [TestCase(TipoVeiculoFipe.Caminhoes, AcaoFipe.Veiculo, "109", "3302", "1997-3", ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/veiculo/109/3302/1997-3.json")]
        public string ValidarCarregamentoDaUrl(TipoVeiculoFipe tipoVeiculo, AcaoFipe acao, params string[] parametros)
        {
            Type type = typeof(ConsultaFipe);
            object consultaFipe = Activator.CreateInstance(type, tipoVeiculo, acao, parametros);
            MethodInfo metodoCarregarUrl = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(metodo => metodo.Name == "CarregarUrl" && metodo.IsPrivate)
                .First();

            return  (string)metodoCarregarUrl.Invoke(consultaFipe, null);
        }

        [TestCase(TipoVeiculoFipe.Carros, "JEEP")]
        [TestCase(TipoVeiculoFipe.Motos, "YAMAHA")]
        [TestCase(TipoVeiculoFipe.Caminhoes, "IVECO")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculoFipe tipoVeiculo, string marcaEsperada)
        {

            IEnumerable<RetornoFipe> retorno = new ConsultaFipe(tipoVeiculo, AcaoFipe.Marcas).Carregar();
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}