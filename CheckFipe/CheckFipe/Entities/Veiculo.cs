using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Entities
{
    public class Veiculo
    {
        public long IdVeiculo { get; set; }
        public long CodigoMarca { get; set; }
        public string CodigoFipe { get; set; }
        public string CodigoAno { get; set; }
        public long NumeroDeConsultas
        {
            get
            {
                return this.ConsultasVeiculo?.Count() ?? 0;
            }
        }

        public IEnumerable<ConsultaVeiculo> ConsultasVeiculo { get; set; }

    }
}
