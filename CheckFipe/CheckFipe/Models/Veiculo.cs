using CheckFipe.Enums;
using CheckFipe.Teste.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckFipe.Models
{
    public class Veiculo
    {
        public string MesReferencia { get; set; }

        public string CodigoFipe { get; set; }

        public Marca Marca { get; set; }

        public Modelo Modelo { get; set; }

        public Ano Ano { get; set; }

        public string AnoModelo { get; set; }

        public string Preco { get; set; }
        public string DescricaoCombustivel { get; set; }

        public static Veiculo Carregar(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno)
        {
            VeiculoRetornoFipe retornoFipe = new ConsultaFipe(tipoVeiculo, AcaoFipe.Veiculo, codigoMarca.ToString(), codigoModelo.ToString(), codigoAno)
                .Carregar<VeiculoRetornoFipe>();

            return new Veiculo()
            {
                CodigoFipe = retornoFipe.CodigoFipe,
                MesReferencia = retornoFipe.MesReferencia,
                Marca = new Marca()
                {
                    Codigo = codigoMarca,
                    Nome = retornoFipe.DescricaoMarca
                },
                Modelo = new Modelo()
                {
                    Codigo = codigoModelo,
                    Nome = retornoFipe.DescricaoModelo
                },
                Ano = new Ano()
                {
                    Codigo = codigoAno,
                    Nome = retornoFipe.AnoModelo.ToString()
                },
                AnoModelo = retornoFipe.AnoModelo,
                Preco = retornoFipe.Preco,
                DescricaoCombustivel = retornoFipe.DescricaoCombustivel
            };
        }
    }
}
