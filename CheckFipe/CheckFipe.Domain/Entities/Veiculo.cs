using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public string CodigoFipe { get; set; }
        public long IdModelo { get; set; }
        public Modelo Modelo { get; set; }
        public string CodigoAnoModelo { get; set; }
        public string AnoModelo { get; set; }
        public string Preco { get; set; }
        public string DescricaoCombustivel { get; set; }

        public long NumeroDeConsultas
        {
            get
            {
                return this.ConsultasVeiculo?.Count() ?? 0;
            }
        }

        public IList<ConsultaVeiculo> ConsultasVeiculo { get; set; }

        public Veiculo() { } //TODO Remover este construtor

        public Veiculo(string codigoFipe, string codigoAno, string anoModelo, string combustivel, string preco, Modelo modelo)
        {
            this.CodigoFipe = codigoFipe;
            this.CodigoAnoModelo = codigoAno;
            this.Preco = preco;
            this.DescricaoCombustivel = combustivel;
            this.AnoModelo = anoModelo;
            this.Modelo = modelo;
            this.IdModelo = modelo.Id;
        }

        public void AddConsultaVeiculo()
        {
            if (this.ConsultasVeiculo == null)
            {
                this.ConsultasVeiculo = new List<ConsultaVeiculo>();
            }

            this.ConsultasVeiculo.Add(new ConsultaVeiculo()
            {
                DataConsultaVeiculo = DateTime.Now
            });
        }
    }
}
