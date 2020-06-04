using CheckFipe.Domain.Enumerators;
using CheckFipe.Infraestructure.Proxy.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Models
{
    public class Modelo
    {
        public long Codigo { get; set; }

        public string Nome { get; set; }

        public static IEnumerable<Modelo> Carregar(TipoVeiculo tipoVeiculo, long codigoMarca)
        {
            return new ConsultaFipe(tipoVeiculo, TipoAcaoFipe.Veiculos, codigoMarca.ToString())
                .Carregar<IEnumerable<RetornoFipe>>()
                .Select(retornoFipe => new Modelo()
                {
                    Codigo = Convert.ToInt64(retornoFipe.Codigo),
                    Nome = retornoFipe.Nome
                })
                .OrderBy(retornoFipe => retornoFipe.Nome);
        }
    }
}
