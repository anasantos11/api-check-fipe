using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckFipe.Infrastructure.Data.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");
            builder.HasKey(veiculo => veiculo.Id);
            builder.Ignore(veiculo => veiculo.NumeroDeConsultas);
        }
    }
}
