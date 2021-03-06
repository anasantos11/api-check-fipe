﻿using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using CheckFipe.Infraestructure.Proxy.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Teste.ModelsTest
{
    public class ModeloServiceTest
    {
        [TestCase(TipoVeiculo.Carros, 21, 4828, "Palio 1.0 ECONOMY Fire Flex 8V 4p")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "750 VIRAGO")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1114 3-Eixos 2p (diesel)")]
        public void ValidarCarregamentoDasMarcas(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModeloEsperado, string nomeModeloEsperado)
        {

            IEnumerable<Modelo> retorno = new ModeloService().Carregar(tipoVeiculo, codigoMarca.ToString());
            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno.Count(modelo => modelo.Id == codigoModeloEsperado && modelo.Nome == nomeModeloEsperado) > 0);
        }
    }
}
