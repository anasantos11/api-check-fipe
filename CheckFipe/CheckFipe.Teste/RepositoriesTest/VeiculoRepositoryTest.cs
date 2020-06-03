using CheckFipe.Context;
using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace CheckFipe.Teste.RepositoriesTest
{
    public class VeiculoRepositoryTest
    {
        [Test]
        public void ValidarCarregarVeiculos()
        {
            using var context = new CheckFipeContextTest();
            new VeiculoRepository(context)
                .Cadastrar(new Veiculo("001267-0", "2013-1", "2013", "gasolina", "R$ 25.000,00", new Modelo()
                {
                    Id = 4828,
                    Nome = "Palio 1.0 ECONOMY Fire Flex 8V 4p",
                    Marca = new Marca()
                    {
                        Id = 21,
                        Nome = "Fiat"
                    }
                }));
            context.SaveChanges();

            var veiculos = new VeiculoRepository(context).Carregar();

            Assert.IsNotNull(veiculos);
            Assert.AreEqual(1, veiculos.Count());
            Assert.IsTrue(veiculos.Any(veiculo => veiculo.IdModelo == 4828 && veiculo.CodigoFipe == "001267-0" && veiculo.CodigoAnoModelo == "2013-1"));
        }

        [Test]
        public void ValidarCadastrarVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {
                new VeiculoRepository(context)
                    .Cadastrar(new Veiculo("827001-5", "1995-1", "1995", "diesel", "R$ 15.000,00", new Modelo()
                    {
                        Id = 3060,
                        Nome = "750 VIRAGO",
                        IdMarca = 101,
                        Marca = new Marca()
                        {
                            Id = 101,
                            Nome = "YAMAHA"
                        }
                    }));

                context.SaveChanges();

                var veiculo = context.Veiculos
                    .Include(veiculo => veiculo.ConsultasVeiculo)
                    .FirstOrDefault(veiculo => veiculo.IdModelo == 3060 && veiculo.CodigoFipe == "827001-5" && veiculo.CodigoAnoModelo == "1995-1");

                Assert.IsNotNull(veiculo);
                Assert.AreEqual(101, veiculo.Modelo.IdMarca);
                Assert.AreEqual("827001-5", veiculo.CodigoFipe);
                Assert.AreEqual("1995-1", veiculo.CodigoAnoModelo);
                Assert.AreEqual("1995", veiculo.AnoModelo);
                Assert.AreEqual("diesel", veiculo.DescricaoCombustivel);
                Assert.AreEqual("R$ 15.000,00", veiculo.Preco);
                Assert.AreEqual("YAMAHA", veiculo.Modelo.Marca.Nome);
                Assert.AreEqual("750 VIRAGO", veiculo.Modelo.Nome);
                Assert.AreEqual(0, veiculo.NumeroDeConsultas);
            }
        }

        [Test]
        public void ValidarCarregarVeiculo()
        {
            using var context = new CheckFipeContextTest();

            new VeiculoRepository(context)
                .Cadastrar(new Veiculo("509001-6", "1997-3", "1997", "diesel", "R$ 20.000,00", new Modelo()
                {
                    Id = 3302,
                    Nome = "1114 3-Eixos 2p (diesel)",
                    Marca = new Marca()
                    {
                        Id = 109,
                        Nome = "MERCEDES-BENZ"
                    }
                }));            
            
            context.SaveChanges();

            var veiculo = new VeiculoRepository(context).Carregar(3302, "509001-6", "1997-3");

            Assert.IsNotNull(veiculo);
            Assert.AreEqual(109, veiculo.Modelo.IdMarca);
            Assert.AreEqual("509001-6", veiculo.CodigoFipe);
            Assert.AreEqual("1997-3", veiculo.CodigoAnoModelo);
            Assert.AreEqual("1997", veiculo.AnoModelo);
            Assert.AreEqual("diesel", veiculo.DescricaoCombustivel);
            Assert.AreEqual("R$ 20.000,00", veiculo.Preco);
            Assert.AreEqual("MERCEDES-BENZ", veiculo.Modelo.Marca.Nome);
            Assert.AreEqual("1114 3-Eixos 2p (diesel)", veiculo.Modelo.Nome);
            Assert.AreEqual(0, veiculo.NumeroDeConsultas);
        }
    }
}
