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
        public string ValidarCarregamentoDaUrl(TipoVeiculoFipe tipoVeiculo, AcaoFipe acao, params string[] parametros)
        {
            Type type = typeof(ConsultaFipe);
            object consultaFipe = Activator.CreateInstance(type, tipoVeiculo, acao, parametros);
            MethodInfo metodoCarregarUrl = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(metodo => metodo.Name == "CarregarUrl" && metodo.IsPrivate)
                .First();

            return  (string)metodoCarregarUrl.Invoke(consultaFipe, null);
        }

        [TestCase(TipoVeiculoFipe.Carros, "Jeep")]
        [TestCase(TipoVeiculoFipe.Motos, "Yamaha")]
        [TestCase(TipoVeiculoFipe.Caminhoes, "Iveco")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculoFipe tipoVeiculo, string marcaEsperada)
        {

            IEnumerable<Marca> retorno = new ConsultaFipe(tipoVeiculo, AcaoFipe.Marcas).Carregar();
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Nome == marcaEsperada) > 0);
        }
    }
}