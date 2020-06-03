using System;

namespace CheckFipe.Domain.Entities
{

    public class ConsultaVeiculo : BaseEntity
    {
        public DateTime DataConsultaVeiculo { get; set; }

        public int IdVeiculo { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
