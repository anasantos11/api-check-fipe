using System;
using System.Text.Json.Serialization;

namespace CheckFipe.Entities
{

    public class ConsultaVeiculo
    {
        [JsonIgnore]
        public long IdConsultaVeiculo { get; set; }

        public DateTime DataConsultaVeiculo { get; set; }

        [JsonIgnore]
        public long IdVeiculo { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
