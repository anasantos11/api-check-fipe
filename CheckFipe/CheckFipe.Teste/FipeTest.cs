using CheckFipe.Enums;
using CheckFipe.Models;
using NUnit.Framework;

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
            return Fipe.CarregarUrl(tipoVeiculo, acao, parametros);
        }
    }
}