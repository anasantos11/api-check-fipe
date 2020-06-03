using CheckFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckFipe.Infrastructure.Data.Mapping
{
    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");
            builder.HasKey(modelo => modelo.Id);
            builder
             .HasOne(modelo => modelo.Marca)
             .WithMany(marca => marca.Modelos)
             .HasForeignKey(modelo => modelo.IdMarca);
        }
    }
}
