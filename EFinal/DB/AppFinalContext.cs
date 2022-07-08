using EFinal_N00194025.DB.Maps;
using EFinal_N00194025.Models;
using Microsoft.EntityFrameworkCore;

namespace EFinal_N00194025.DB
{
    public class AppFinalContext : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }

        public AppFinalContext(DbContextOptions<AppFinalContext> options) : base(options) { }

        public AppFinalContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new GastoMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());

        }
    }
}
