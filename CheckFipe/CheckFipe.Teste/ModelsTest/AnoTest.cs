﻿using CheckFipe.Domain.Enumerators;
using CheckFipe.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.ModelsTest
{
    public class AnoTest
    {
        [TestCase(TipoVeiculo.Carros, 21, 4828, "2013-1", "2013 Gasolina")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "1995-1", "1995")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1997-3", "1997")]
        public void ValidarCarregamentoDosAnos(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAnoEsperado, string descricaoAnoEsperado)
        {

            IEnumerable<Ano> retorno = Ano.Carregar(tipoVeiculo, codigoMarca, codigoModelo);
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(marca => marca.Codigo == codigoAnoEsperado && marca.Nome == descricaoAnoEsperado) > 0);
        }
    }
}
