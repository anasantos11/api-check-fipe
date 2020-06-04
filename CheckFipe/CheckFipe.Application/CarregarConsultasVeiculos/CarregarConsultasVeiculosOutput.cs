using AutoMapper;
using CheckFipe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CheckFipe.Application.CarregarConsultasVeiculos
{
    public class CarregarConsultasVeiculosOutput
    {
        public DateTime DataConsultaVeiculo { get; set; }
        public VeiculoOutput Veiculo { get; set; }
    }
}
