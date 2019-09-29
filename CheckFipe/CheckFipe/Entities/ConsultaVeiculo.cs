using System;

namespace CheckFipe.Entities
{

    public class ConsultaVeiculo
    {
        public long IdConsultaVeiculo { get; set; }

        public DateTime DataConsultaVeiculo { get; set; }

        public long IdVeiculo { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
