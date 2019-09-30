using CheckFipe.Contracts;
using CheckFipe.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void CadastrarConsultaVeiculo(long codigoMarca, string codigoFipe, string codigoAno, string anoModelo, string combustivel, string preco)
        {
            VeiculoRepository veiculoRepository = new VeiculoRepository(this.ConsultaVeiculoContext, codigoMarca, codigoFipe, codigoAno);
            Veiculo veiculo = veiculoRepository.CarregarVeiculo();

            if (veiculo == null)
            {
                this.ConsultaVeiculoContext.ConsultasVeiculo.Add(new ConsultaVeiculo()
                {
                    DataConsultaVeiculo = DateTime.Now,
                    Veiculo = veiculoRepository.CadastrarVeiculo(anoModelo, combustivel, preco)
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
