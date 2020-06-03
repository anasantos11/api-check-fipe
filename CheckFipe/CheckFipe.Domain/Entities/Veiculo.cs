using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public long CodigoMarca { get; set; }
        public string CodigoFipe { get; set; }
        public string CodigoAno { get; set; }
        public string Preco { get; set; }
        public string DescricaoCombustivel { get; set; }
        public string AnoModelo { get; set; }
        public string DescricaoMarca { get; set; }
        public string DescricaoModelo { get; set; }

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
