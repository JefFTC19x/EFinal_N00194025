using EFinal_N00194025.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFinal_N00194025.DB.Maps
{
    public class IngresoMap : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {
            builder.ToTable("Ingreso");
            builder.HasKey(o => o.Id);
        }
    }
}
