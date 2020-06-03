using CheckFipe.Context;
using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Repositories;
using CheckFipe.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace CheckFipe.Teste.RepositoriesTest
{
    public class ConsultaVeiculoRepositoryTest
    {
        [Test]
        public void ValidarCarregarConsultasVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {
                new ConsultaVeiculoRepository(context).Cadastrar(new ConsultaVeiculo()
                {
                    DataConsultaVeiculo = DateTime.Now,
                    IdVeiculo = 1,
                    Veiculo = new Veiculo()
                    {
                        Id = 1,
                        CodigoMarca = 101,
                        CodigoFipe = "827001-5",
                        CodigoAno = "1995-1",
                        Preco = "R$ 15.000,00",
                        DescricaoCombustivel = "diesel",
                        AnoModelo = "1995",
                        DescricaoMarca = "YAMAHA",
                        DescricaoModelo = "750 VIRAGO"
                    }
                });
                context.SaveChanges();

                var consultas = new ConsultaVeiculoRepository(context).Carregar();
                var consultaVeiculo = consultas
                    .FirstOrDefault(consulta =>
                        consulta.Veiculo.CodigoMarca == 101 &&
                        consulta.Veiculo.CodigoFipe == "827001-5" &&
                        consulta.Veiculo.CodigoAno == "1995-1");

                Assert.IsNotNull(consultas);
                Assert.AreEqual(1, consultas.Count());
                Assert.IsNotNull(consultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.Id);
                Assert.AreEqual(1, consultaVeiculo.IdVeiculo);
                Assert.AreEqual(101, consultaVeiculo.Veiculo.CodigoMarca);
                Assert.AreEqual("827001-5", consultaVeiculo.Veiculo.CodigoFipe);
                Assert.AreEqual("1995-1", consultaVeiculo.Veiculo.CodigoAno);
                Assert.AreEqual(1, consultaVeiculo.Veiculo.NumeroDeConsultas);
            }
        }
    }
}

