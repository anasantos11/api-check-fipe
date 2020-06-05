﻿using CheckFipe.Teste.ContextTest;
using CheckFipe.Domain.Entities;
using CheckFipe.Domain.Enumerators;
using NUnit.Framework;
using CheckFipe.Application.BuscarVeiculo;
using CheckFipe.Infraestructure.Proxy.Services;
using CheckFipe.Infrastructure.Data.Repositories;
using AutoMapper;
using CheckFipe.Application;

namespace CheckFipe.Teste.UseCaseTest
{
    public class BuscarVeiculoTabelaFipeTest
    {
        [TestCase(TipoVeiculo.Carros, 21, 4828, "2013-1", "001267-0", "Fiat", "Palio 1.0 ECONOMY Fire Flex 8V 4p", "2013", "Gasolina")]
        [TestCase(TipoVeiculo.Motos, 101, 3060, "1995-1", "827001-5", "YAMAHA", "750 VIRAGO", "1995", "Gasolina")]
        [TestCase(TipoVeiculo.Caminhoes, 109, 3302, "1997-3", "509001-6", "MERCEDES-BENZ", "1114 3-Eixos 2p (diesel)", "1997", "Diesel")]
        public void ValidarCarregamentoDosAnos(TipoVeiculo tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string marcaEsperada, string modeloEsperado, string anoEsperado, string combustivelEsperado)
        {
            IMapper mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfig());
            }).CreateMapper();

            VeiculoOutput veiculoBuscado = new BuscarVeiculoUseCase(new VeiculoService(), new VeiculoRepository(new CheckFipeContextTest()), mapperConfig)
                .Execute(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);

            Assert.IsNotNull(veiculoBuscado);
            Assert.AreEqual(marcaEsperada, veiculoBuscado.DescricaoMarca);
            Assert.AreEqual(modeloEsperado, veiculoBuscado.DescricaoModelo);
            Assert.AreEqual(codigoFipeEsperado, veiculoBuscado.CodigoFipe);
            Assert.AreEqual(anoEsperado, veiculoBuscado.AnoModelo);
            Assert.AreEqual(combustivelEsperado, veiculoBuscado.DescricaoCombustivel);
            //TODO Colocar MesReferencia no veículo Assert.IsNotNull(veiculoBuscado.MesReferencia);
            Assert.IsNotNull(veiculoBuscado.Preco);
        }
    }
}
