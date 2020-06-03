using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckFipe.Infrastructure.Data.Mapping
{
    public class ConsultaVeiculoMap : IEntityTypeConfiguration<ConsultaVeiculo>
    {
        public void Configure(EntityTypeBuilder<ConsultaVeiculo> builder)
        {
            builder.ToTable("ConsultaVeiculo");
            builder.HasKey(consultaVeiculo => consultaVeiculo.Id);
            builder
                 .HasOne(consultaVeiculo => consultaVeiculo.Veiculo)
                 .WithMany(veiculo => veiculo.ConsultasVeiculo)
                 .HasForeignKey(consultaVeiculo => consultaVeiculo.IdVeiculo);
        }
    }
}
