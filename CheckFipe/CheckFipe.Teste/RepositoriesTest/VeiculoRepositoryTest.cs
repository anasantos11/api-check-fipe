using CheckFipe.Context;
using CheckFipe.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckFipe.Teste.RepositoriesTest
{
    public class VeiculoRepositoryTest
    {
        [Test]
        public void ValidarCarregarVeiculos()
        {
            using (var context = new CheckFipeContextTest())
            {

                new VeiculoRepository(context, 21, "001267-0", "2013-1").CadastrarVeiculo("2013", "gasolina", "R$ 25.000,00", "Fiat", "Palio 1.0 ECONOMY Fire Flex 8V 4p");

                var veiculo = context.Veiculos
                    .Include(veiculo => veiculo.ConsultasVeiculo)
                    .FirstOrDefault(veiculo => veiculo.CodigoMarca == 21 && veiculo.CodigoFipe == "001267-0" && veiculo.CodigoAno == "2013-1");

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(21, veiculo.CodigoMarca);
                Assert.AreEqual("001267-0", veiculo.CodigoFipe);
                Assert.AreEqual("2013-1", veiculo.CodigoAno);
                Assert.AreEqual("2013", veiculo.AnoModelo);
                Assert.AreEqual("gasolina", veiculo.DescricaoCombustivel);
                Assert.AreEqual("R$ 25.000,00", veiculo.Preco);
                Assert.AreEqual("Fiat", veiculo.DescricaoMarca);
                Assert.AreEqual("Palio 1.0 ECONOMY Fire Flex 8V 4p", veiculo.DescricaoModelo);

                Assert.AreEqual(0, veiculo.NumeroDeConsultas);

                var veiculos = new VeiculoRepository(context).CarregarVeiculos();

                Assert.IsNotNull(veiculos);
                Assert.AreEqual(1, veiculos.Count());
                Assert.IsTrue(veiculos.Any(veiculo => veiculo.CodigoMarca == 21 && veiculo.CodigoFipe == "001267-0" && veiculo.CodigoAno == "2013-1"));
            }
        }

        [Test]
        public void ValidarCadastrarVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {
                new VeiculoRepository(context, 101, "827001-5", "1995-1").CadastrarVeiculo("1995", "diesel", "R$ 15.000,00", "YAMAHA", "750 VIRAGO");

                var veiculo = context.Veiculos
                    .Include(veiculo => veiculo.ConsultasVeiculo)
                    .FirstOrDefault(veiculo => veiculo.CodigoMarca == 101 && veiculo.CodigoFipe == "827001-5" && veiculo.CodigoAno == "1995-1");

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(101, veiculo.CodigoMarca);
                Assert.AreEqual("827001-5", veiculo.CodigoFipe);
                Assert.AreEqual("1995-1", veiculo.CodigoAno);
                Assert.AreEqual("1995", veiculo.AnoModelo);
                Assert.AreEqual("diesel", veiculo.DescricaoCombustivel);
                Assert.AreEqual("R$ 15.000,00", veiculo.Preco);
                Assert.AreEqual("YAMAHA", veiculo.DescricaoMarca);
                Assert.AreEqual("750 VIRAGO", veiculo.DescricaoModelo);
                Assert.AreEqual(0, veiculo.NumeroDeConsultas);
            }
        }

        [Test]
        public void ValidarCarregarVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {

                new VeiculoRepository(context, 109, "509001-6", "1997-3").CadastrarVeiculo("1997", "diesel", "R$ 20.000,00", "MERCEDES-BENZ", "1114 3-Eixos 2p (diesel)");

                var veiculo = new VeiculoRepository(context, 109, "509001-6", "1997-3").CarregarVeiculo();

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(109, veiculo.CodigoMarca);
                Assert.AreEqual("509001-6", veiculo.CodigoFipe);
                Assert.AreEqual("1997-3", veiculo.CodigoAno);
                Assert.AreEqual("1997", veiculo.AnoModelo);
                Assert.AreEqual("diesel", veiculo.DescricaoCombustivel);
                Assert.AreEqual("R$ 20.000,00", veiculo.Preco);
                Assert.AreEqual("MERCEDES-BENZ", veiculo.DescricaoMarca);
                Assert.AreEqual("1114 3-Eixos 2p (diesel)", veiculo.DescricaoModelo);
                Assert.AreEqual(0, veiculo.NumeroDeConsultas);
            }
        }
    }
}
