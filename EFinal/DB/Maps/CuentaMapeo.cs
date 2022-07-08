using EFinal_N00194025.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFinal_N00194025.DB.Maps
{
    public class CuentaMap : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuenta");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Gastos).WithOne().HasForeignKey(o => o.CuentaId);
            builder.HasMany(o => o.Ingresos).WithOne().HasForeignKey(o => o.CuentaId);


        }
    }
}