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

                new VeiculoRepository(context, 21, "001267-0", "2013-1").CadastrarVeiculo();
                context.SaveChanges();

                var veiculo = context.Veiculos
                    .Include(veiculo => veiculo.ConsultasVeiculo)
                    .FirstOrDefault(veiculo => veiculo.CodigoMarca == 21 && veiculo.CodigoFipe == "001267-0" && veiculo.CodigoAno == "2013-1");

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(21, veiculo.CodigoMarca);
                Assert.AreEqual("001267-0", veiculo.CodigoFipe);
                Assert.AreEqual("2013-1", veiculo.CodigoAno);
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
                new VeiculoRepository(context, 101, "827001-5", "1995-1").CadastrarVeiculo();
                context.SaveChanges();

                var veiculo = context.Veiculos
                    .Include(veiculo => veiculo.ConsultasVeiculo)
                    .FirstOrDefault(veiculo => veiculo.CodigoMarca == 101 && veiculo.CodigoFipe == "827001-5" && veiculo.CodigoAno == "1995-1");

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(101, veiculo.CodigoMarca);
                Assert.AreEqual("827001-5", veiculo.CodigoFipe);
                Assert.AreEqual("1995-1", veiculo.CodigoAno);
                Assert.AreEqual(0, veiculo.NumeroDeConsultas);
            }
        }

        [Test]
        public void ValidarCarregarVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {

                new VeiculoRepository(context, 109, "509001-6", "1997-3").CadastrarVeiculo();
                context.SaveChanges();

                var veiculoCadastrado = context.Veiculos
                    .Include(veiculo => veiculo.ConsultasVeiculo)
                    .FirstOrDefault(veiculo => veiculo.CodigoMarca == 109 && veiculo.CodigoFipe == "509001-6" && veiculo.CodigoAno == "1997-3");

                Assert.IsNotNull(veiculoCadastrado);
                Assert.AreEqual(109, veiculoCadastrado.CodigoMarca);
                Assert.AreEqual("509001-6", veiculoCadastrado.CodigoFipe);
                Assert.AreEqual("1997-3", veiculoCadastrado.CodigoAno);
                Assert.AreEqual(0, veiculoCadastrado.NumeroDeConsultas);

                var veiculo = new VeiculoRepository(context, 109, "509001-6", "1997-3").CarregarVeiculo();

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(109, veiculo.CodigoMarca);
                Assert.AreEqual("509001-6", veiculo.CodigoFipe);
                Assert.AreEqual("1997-3", veiculo.CodigoAno);
                Assert.AreEqual(0, veiculo.NumeroDeConsultas);
            }
        }
    }
}
