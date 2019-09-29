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
    public class ConsultaVeiculoRepositoryTest
    {

        [Test]
        public void ValidarCadastroConsultaVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {
                new ConsultaVeiculoRepository(context).CadastrarConsultaVeiculo(21, "001267-0", "2013-1");
                context.SaveChanges();

                var consultas = context.ConsultasVeiculo.Include(consulta => consulta.Veiculo);
                var consultaVeiculo = consultas
                    .FirstOrDefault(consulta =>
                        consulta.Veiculo.CodigoMarca == 21 &&
                        consulta.Veiculo.CodigoFipe == "001267-0" &&
                        consulta.Veiculo.CodigoAno == "2013-1");

                Assert.IsNotNull(consultas);
                Assert.AreEqual(1, consultas.Count());
                Assert.IsNotNull(consultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.IdConsultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.IdVeiculo);
                Assert.AreEqual(21, consultaVeiculo.Veiculo.CodigoMarca);
                Assert.AreEqual("001267-0", consultaVeiculo.Veiculo.CodigoFipe);
                Assert.AreEqual("2013-1", consultaVeiculo.Veiculo.CodigoAno);
                Assert.AreEqual(1, consultaVeiculo.Veiculo.NumeroDeConsultas);
            }
        }


        [Test]
        public void ValidarCarregarConsultasVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {
                new ConsultaVeiculoRepository(context).CadastrarConsultaVeiculo(101, "827001-5", "1995-1");
                context.SaveChanges();

                var consultas = new ConsultaVeiculoRepository(context).CarregarConsultasVeiculos();
                var consultaVeiculo = consultas
                    .FirstOrDefault(consulta =>
                        consulta.Veiculo.CodigoMarca == 101 &&
                        consulta.Veiculo.CodigoFipe == "827001-5" &&
                        consulta.Veiculo.CodigoAno == "1995-1");

                Assert.IsNotNull(consultas);
                Assert.AreEqual(1, consultas.Count());
                Assert.IsNotNull(consultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.IdConsultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.IdVeiculo);
                Assert.AreEqual(101, consultaVeiculo.Veiculo.CodigoMarca);
                Assert.AreEqual("827001-5", consultaVeiculo.Veiculo.CodigoFipe);
                Assert.AreEqual("1995-1", consultaVeiculo.Veiculo.CodigoAno);
                Assert.AreEqual(1, consultaVeiculo.Veiculo.NumeroDeConsultas);
            }
        }
    }
}

