using CheckFipe.Contracts;
using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CheckFipe.Repositories
{
    public class VeiculoRepository
    {
        public VeiculoRepository(ICheckFipeContext context)
        {
            this.VeiculoContext = context;
        }

        public VeiculoRepository(ICheckFipeContext context, long codigoMarca, string codigoFipe, string codigoAno)
        {
            this.VeiculoContext = context;
            this.CodigoMarca = codigoMarca;
            this.CodigoFipe = codigoFipe;
            this.CodigoAno = codigoAno;
        }

        private ICheckFipeContext VeiculoContext { get; }

        private long CodigoMarca { get; set; }
        private string CodigoFipe { get; set; }
        private string CodigoAno { get; set; }

        public IEnumerable<Veiculo> CarregarVeiculos()
        {
            return this.VeiculoContext.Veiculos.Include(veiculo => veiculo.ConsultasVeiculo);
        }

        public Veiculo CarregarVeiculo()
        {
            return this.VeiculoContext.Veiculos
                    .Where(veiculo => veiculo.CodigoMarca == this.CodigoMarca &&
                                                veiculo.CodigoFipe == this.CodigoFipe &&
                                                veiculo.CodigoAno == this.CodigoAno)
                    .FirstOrDefault();
        }

        public Veiculo CadastrarVeiculo(string anoModelo, string combustivel, string preco, string descricaoMarca, string descricaoModelo)
        {
            var veiculo = new Veiculo()
            {
                CodigoMarca = this.CodigoMarca,
                CodigoFipe = this.CodigoFipe,
                CodigoAno = this.CodigoAno,
                AnoModelo = anoModelo,
                DescricaoCombustivel = combustivel,
                Preco = preco,
                DescricaoMarca = descricaoMarca,
                DescricaoModelo = descricaoModelo

            };
            this.VeiculoContext.Veiculos.Add(veiculo);
            this.VeiculoContext.SaveChanges();
            return veiculo;
        }
    }
}
