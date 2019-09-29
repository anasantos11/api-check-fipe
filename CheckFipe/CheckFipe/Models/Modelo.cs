using CheckFipe.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Models
{
    public class Modelo
    {
        public long Codigo { get; set; }

        public string Nome { get; set; }

        public static IEnumerable<Modelo> Carregar(TipoVeiculoFipe tipoVeiculo, long codigoMarca)
        {
            return new ConsultaFipe(tipoVeiculo, AcaoFipe.Veiculos, codigoMarca.ToString())
                .Carregar()
                .Select(retornoFipe => new Modelo()
                {
                    Codigo = retornoFipe.Codigo,
                    Nome = retornoFipe.Nome
                });
        }
    }
}
