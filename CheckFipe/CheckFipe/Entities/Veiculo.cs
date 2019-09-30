using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CheckFipe.Entities
{
    public class Veiculo
    {
        [JsonIgnore]
        public long IdVeiculo { get; set; }
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

        [JsonIgnore]
        public IEnumerable<ConsultaVeiculo> ConsultasVeiculo { get; set; }

    }
}
