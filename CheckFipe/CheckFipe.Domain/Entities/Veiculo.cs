using System;
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

        public IList<ConsultaVeiculo> ConsultasVeiculo { get; set; }

        public Veiculo() { }

        public Veiculo(long codigoMarca, string codigoFipe, string codigoAno, string anoModelo, string combustivel, string preco, string descricaoMarca, string descricaoModelo)
        {
            this.CodigoMarca = codigoMarca;
            this.CodigoFipe = codigoFipe;
            this.CodigoAno = codigoAno;
            this.Preco = preco;
            this.DescricaoCombustivel = combustivel;
            this.AnoModelo = anoModelo;
            this.DescricaoMarca = descricaoMarca;
            this.DescricaoModelo = descricaoModelo;
        }

        public void AddConsultaVeiculo()
        {
            this.ConsultasVeiculo.Add(new ConsultaVeiculo()
            {
                DataConsultaVeiculo = DateTime.Now
            });
        }
    }
}
