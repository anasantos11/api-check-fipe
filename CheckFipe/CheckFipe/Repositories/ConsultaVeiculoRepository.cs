using CheckFipe.Domain.Entities;
using CheckFipe.Infrastructure.Data.Interfaces;
using CheckFipe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CheckFipe.Repositories
{
    public class ConsultaVeiculoRepository
    {
        public ConsultaVeiculoRepository(ICheckFipeContext context)
        {
            this.ConsultaVeiculoContext = context;
        }

        private ICheckFipeContext ConsultaVeiculoContext { get; }

        public IEnumerable<ConsultaVeiculo> CarregarConsultasVeiculos()
        {
            return this.ConsultaVeiculoContext.ConsultasVeiculo.Include(consulta => consulta.Veiculo);
        }

        public void CadastrarConsultaVeiculo(long codigoMarca, string codigoAno, VeiculoRetornoFipe veiculoFipe)
        {
            VeiculoRepository veiculoRepository = new VeiculoRepository(this.ConsultaVeiculoContext, codigoMarca, veiculoFipe.CodigoFipe, codigoAno);
            Veiculo veiculo = veiculoRepository.CarregarVeiculo();

            if (veiculo == null)
            {
                this.ConsultaVeiculoContext.ConsultasVeiculo.Add(new ConsultaVeiculo()
                {
                    DataConsultaVeiculo = DateTime.Now,
                    Veiculo = veiculoRepository
                        .CadastrarVeiculo(veiculoFipe.AnoModelo, veiculoFipe.DescricaoCombustivel, veiculoFipe.Preco, veiculoFipe.DescricaoMarca, veiculoFipe.DescricaoModelo)
                });
            }
            else
            {
                this.ConsultaVeiculoContext.ConsultasVeiculo.Add(new ConsultaVeiculo()
                {
                    DataConsultaVeiculo = DateTime.Now,
                    Veiculo = veiculo
                });
            }
            this.ConsultaVeiculoContext.SaveChanges();
        }
    }
}
