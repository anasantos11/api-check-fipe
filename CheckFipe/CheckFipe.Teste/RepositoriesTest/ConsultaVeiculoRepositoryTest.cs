using CheckFipe.Context;
using CheckFipe.Models;
using CheckFipe.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace CheckFipe.Teste.RepositoriesTest
{
    public class ConsultaVeiculoRepositoryTest
    {

        [Test]
        public void ValidarCadastroConsultaVeiculo()
        {
            using (var context = new CheckFipeContextTest())
            {
                var retornoFipe = new VeiculoRetornoFipe()
                {
                    AnoModelo = "2013",
                    DescricaoCombustivel = "gasolina",
                    Preco = "R$ 25.000,00",
                    DescricaoMarca = "Fiat",
                    DescricaoModelo = "Palio 1.0 ECONOMY Fire Flex 8V 4p",
                    CodigoFipe = "001267-0",
                    Codigo = "2013",
                    Nome = "Palio 1.0 ECONOMY Fire Flex 8V 4p"
                };
                new ConsultaVeiculoRepository(context).CadastrarConsultaVeiculo(21, "2013-1", retornoFipe);

                var consultas = context.ConsultasVeiculo.Include(consulta => consulta.Veiculo);
                var consultaVeiculo = consultas
                    .FirstOrDefault(consulta =>
                        consulta.Veiculo.CodigoMarca == 21 &&
                        consulta.Veiculo.CodigoFipe == "001267-0" &&
                        consulta.Veiculo.CodigoAno == "2013-1");

                Assert.IsNotNull(consultas);
                Assert.AreEqual(1, consultas.Count());
                Assert.IsNotNull(consultaVeiculo);
                Assert.AreEqual(1, consultaVeiculo.Id);
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
                var retornoFipe = new VeiculoRetornoFipe()
                {
                    AnoModelo = "1995",
                    DescricaoCombustivel = "diesel",
                    Preco = "R$ 15.000,00",
                    DescricaoMarca = "YAMAHA",
                    DescricaoModelo = "750 VIRAGO",
                    CodigoFipe = "827001-5",
                    Codigo = "1995",
                    Nome = "750 VIRAGO"
                };
                new ConsultaVeiculoRepository(context).CadastrarConsultaVeiculo(101, "1995-1", retornoFipe);

                var consultas = new ConsultaVeiculoRepository(context).CarregarConsultasVeiculos();
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

