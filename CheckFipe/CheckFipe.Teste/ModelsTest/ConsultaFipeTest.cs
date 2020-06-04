using CheckFipe.Enums;
using CheckFipe.Domain.Enumerators;
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

        [TestCase(TipoVeiculo.Carros, AcaoFipe.Marcas, ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/marcas.json")]
        [TestCase(TipoVeiculo.Motos, AcaoFipe.Marcas, ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/marcas.json")]
        [TestCase(TipoVeiculo.Caminhoes, AcaoFipe.Marcas, ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/marcas.json")]
        [TestCase(TipoVeiculo.Carros, AcaoFipe.Veiculos, "21", ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/veiculos/21.json")]
        [TestCase(TipoVeiculo.Motos, AcaoFipe.Veiculos, "101", ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/veiculos/101.json")]
        [TestCase(TipoVeiculo.Caminhoes, AcaoFipe.Veiculos, "109", ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/veiculos/109.json")]
        [TestCase(TipoVeiculo.Carros, AcaoFipe.Veiculo, "21", "4828", ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/veiculo/21/4828.json")]
        [TestCase(TipoVeiculo.Motos, AcaoFipe.Veiculo, "101", "3060", ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/veiculo/101/3060.json")]
        [TestCase(TipoVeiculo.Caminhoes, AcaoFipe.Veiculo, "109", "3302", ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/veiculo/109/3302.json")]
        [TestCase(TipoVeiculo.Carros, AcaoFipe.Veiculo, "21", "4828", "2013-1", ExpectedResult = "http://fipeapi.appspot.com/api/1/carros/veiculo/21/4828/2013-1.json")]
        [TestCase(TipoVeiculo.Motos, AcaoFipe.Veiculo, "101", "3060", "1995-1", ExpectedResult = "http://fipeapi.appspot.com/api/1/motos/veiculo/101/3060/1995-1.json")]
        [TestCase(TipoVeiculo.Caminhoes, AcaoFipe.Veiculo, "109", "3302", "1997-3", ExpectedResult = "http://fipeapi.appspot.com/api/1/caminhoes/veiculo/109/3302/1997-3.json")]
        public string ValidarCarregamentoDaUrl(TipoVeiculo tipoVeiculo, AcaoFipe acao, params string[] parametros)
        {
            Type type = typeof(ConsultaFipe);
            object consultaFipe = Activator.CreateInstance(type, tipoVeiculo, acao, parametros);
            MethodInfo metodoCarregarUrl = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(metodo => metodo.Name == "CarregarUrl" && metodo.IsPrivate)
                .First();

            return (string)metodoCarregarUrl.Invoke(consultaFipe, null);
        }

        [TestCase(TipoVeiculo.Carros, "JEEP")]
        [TestCase(TipoVeiculo.Motos, "YAMAHA")]
        [TestCase(TipoVeiculo.Caminhoes, "IVECO")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculo tipoVeiculo, string marcaEsperada)
        {

            IEnumerable<RetornoFipe> retorno = new ConsultaFipe(tipoVeiculo, AcaoFipe.Marcas).Carregar<IEnumerable<RetornoFipe>>();
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}