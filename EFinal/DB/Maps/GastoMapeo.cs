using EFinal_N00194025.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFinal_N00194025.DB.Maps
{
    public class GastoMap : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("Gasto");
            builder.HasKey(o => o.Id);
        }
    }
}