using System.Collections.Generic;
using EFinal_N00194025.Controllers;
using EFinal_N00194025.Models;
using EFinal_N00194025.Servicios;
using Moq;
using NUnit.Framework;

namespace EFinal_N00194025
{
    class PruebasUnitarias
    {
        [Test]
        public void pruebaGastostotales()
        {
            var cuentaMoq = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMoq.Object);
            var gastos = new List<Gasto>();
            gastos.Add(new Gasto() { Monto = 30, Descripcion = "mas 30", CuentaId = 17 });
            gastos.Add(new Gasto() { Monto = 40, Descripcion = "mas 40", CuentaId = 17 });
            gastos.Add(new Gasto() { Monto = 50, Descripcion = "mas 50", CuentaId = 17 });

            ICuentaService servicio = new CuentaService();
      
            Assert.AreEqual(servicio.Gastostotales(gastos),120);
        }
        [Test]
        public void pruebaIngresostotales()
        {
            var cuentaMoq = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMoq.Object);
            var ingresos = new List<Ingreso>();
            ingresos.Add(new Ingreso() { Monto = 20, Descripcion = "MAS 50", CuentaId = 16 });
            ingresos.Add(new Ingreso() { Monto = 50, Descripcion = "MAS 60", CuentaId = 16 });
            ingresos.Add(new Ingreso() { Monto = 10, Descripcion = "MAS 70", CuentaId = 16 });

            ICuentaService servicio = new CuentaService();

            Assert.AreEqual(servicio.IngresosTotales(ingresos), 80);
        }
        [Test]
        public void pruebaSaldoTotal()
        {
            var cuentaMoq = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMoq.Object);
            var cuentas = new List<Cuenta>();
            cuentas.Add(new Cuenta() { Saldo = 20 });
            cuentas.Add(new Cuenta() { Saldo = 100 });
            cuentas.Add(new Cuenta() { Saldo = 90 });

            ICuentaService servicio = new CuentaService();

            Assert.AreEqual(servicio.SaldoTotal(cuentas), 210);
        }
    }
}
