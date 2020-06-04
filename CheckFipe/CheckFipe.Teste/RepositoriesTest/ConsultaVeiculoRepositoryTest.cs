using CheckFipe.Teste.ContextTest;
using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Repositories;
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
                        CodigoFipe = "827001-5",
                        CodigoAnoModelo = "1995-1",
                        Preco = "R$ 15.000,00",
                        DescricaoCombustivel = "diesel",
                        AnoModelo = "1995",
                        Modelo = new Modelo()
                        {
                            Id = 360,
                            Nome = "750 VIRAGO",
                            Marca = new Marca()
                            {
                                Id = 101,
                                Nome = "YAMAHA"
                            }
                        }
                    }
                });
                context.SaveChanges();

                var consultas = new ConsultaVeiculoRepository(context).Carregar();
                var consultaVeiculo = consultas
                    .FirstOrDefault(consulta =>
                        consulta.Veiculo.IdModelo == 360 &&
                        consulta.Veiculo.CodigoFipe == "827001-5" &&
                        consulta.Veiculo.CodigoAnoModelo == "1995-1");

                Assert.IsNotNull(consultas);
                Assert.AreEqual(1, consultas.Count());
                Assert.IsNotNull(consultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.Id);
                Assert.AreEqual(1, consultaVeiculo.IdVeiculo);
                Assert.AreEqual("827001-5", consultaVeiculo.Veiculo.CodigoFipe);
                Assert.AreEqual(1, consultaVeiculo.Veiculo.NumeroDeConsultas);
            }
        }
    }
}

