using CheckFipe.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Models
{
    public class Marca
    {
        public long Codigo { get; set; }

        public string Nome { get; set; }

        public static IEnumerable<Marca> Carregar(TipoVeiculoFipe tipoVeiculo)
        {
            return new ConsultaFipe(tipoVeiculo, AcaoFipe.Marcas)
                .Carregar()
                .Select(retornoFipe => new Marca()
                {
                    Codigo = retornoFipe.Codigo,
                    Nome = retornoFipe.Nome
                });
        }
    }
}
