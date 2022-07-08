using System.Collections.Generic;
using EFinal_N00194025.Controllers;
using EFinal_N00194025.Models;
using EFinal_N00194025.Servicios;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace EFinal_N00194025
{
    class PruebasControlador
    {
        [Test]
        public void pruebaIndex()
        {
            var cuentaMop = new Mock<ICuentaService>();
            cuentaMop.Setup(o => o.ListarCuentas()).Returns(new List<Cuenta>());
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Index() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void pruebaGastos()
        {

            var cuentaMop = new Mock<ICuentaService>();
            cuentaMop.Setup(o => o.ListarGastos()).Returns(new List<Gasto>());
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Gastos() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        [Test]
        public void pruebaIngresos()
        {
            var cuentaMop = new Mock<ICuentaService>();
            cuentaMop.Setup(o => o.ListarIngresos()).Returns(new List<Ingreso>());
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Ingresos() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        
        
        [Test]
        public void pruebaIngresar()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Ingresar() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void pruebaPostFallidoIngresar()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Ingresar(new Ingreso()) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void pruebaPostOkIngresar()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Ingresar(new Ingreso() { Monto = 50, Descripcion="UN INGRESO DE 50",CuentaId=16 });
            Assert.IsInstanceOf<RedirectToActionResult>(vista);
        }
        
        
        [Test]
        public void pruebaPostFallidoGastar()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Gastar(new Gasto()) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void pruebaPostOkGastar()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Gastar(new Gasto() { Monto = 30, Descripcion = "UN GASTO DE 30", CuentaId = 16 });
            Assert.IsInstanceOf<RedirectToActionResult>(vista);
        }
        [Test]
        public void pruebaGastar()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Gastar() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }

        
        
        [Test]
        public void pruebaCrearCuenta()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.Crear() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void pruebaPostOkCrearCuenta()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.GuardarCuenta(new Cuenta() {Nombre="CUENTA DE SOLES",Categoria="propia", Saldo = 40, Moneda = "SOLES"}) ;
            Assert.IsInstanceOf<RedirectToActionResult>(vista);
        }
        [Test]
        public void pruebaPostFallidoCrearCuenta()
        {
            var cuentaMop = new Mock<ICuentaService>();
            var controller = new HomeController(cuentaMop.Object);
            var vista = controller.GuardarCuenta(new Cuenta() ) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
    }
}
