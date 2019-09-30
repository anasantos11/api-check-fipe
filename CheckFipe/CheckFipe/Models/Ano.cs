using CheckFipe.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Models
{
    public class Ano
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public static IEnumerable<Ano> Carregar(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo)
        {
            return new ConsultaFipe(tipoVeiculo, AcaoFipe.Veiculo, codigoMarca.ToString(), codigoModelo.ToString())
                .Carregar<IEnumerable<RetornoFipe>>()
                .Select(retornoFipe => new Ano()
                {
                    Codigo = retornoFipe.Codigo,
                    Nome = retornoFipe.Nome
                });
        }
    }
}
