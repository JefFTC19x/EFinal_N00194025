using EFinal_N00194025.Models;
using EFinal_N00194025.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace EFinal_N00194025.Controllers
{
    public class HomeController : Controller
    {
        private ICuentaService cuentaService;
        public HomeController(ICuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        public IActionResult Index()
        {
            
            ViewBag.gastos = cuentaService.Gastostotales(cuentaService.ListarGastos());
            ViewBag.ingresos = cuentaService.IngresosTotales(cuentaService.ListarIngresos());
            ViewBag.total = cuentaService.SaldoTotal(cuentaService.ListarCuentas());
            ViewBag.gastado = cuentaService.ListarGastos();
            ViewBag.ingresado = cuentaService.ListarIngresos();
            var cuentas = cuentaService.ListarCuentas();
            
            return View(cuentas);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GuardarCuenta(Cuenta cuenta)
        {
            Validaciones(cuenta);
            if (!ModelState.IsValid) return View("crear");
            cuentaService.CrearCuenta(cuenta);
            return RedirectToAction("Index");
        }

        public ActionResult Ingresos()
        {
            ViewBag.cuenta = cuentaService.ListarCuentas();
            var ingresos = cuentaService.ListarIngresos();
            
            return View(ingresos);
        }

        public ActionResult Gastos()
        {
            ViewBag.cuenta = cuentaService.ListarCuentas();
            var gastos = cuentaService.ListarGastos();
            return View(gastos);
        }


        [HttpGet]
        public ActionResult Ingresar()
        {
            ViewBag.cuentas = cuentaService.ListarCuentas();
            return View();
        }
        [HttpPost]
        public ActionResult Ingresar(Ingreso ingreso)
        {
            ViewBag.cuentas = cuentaService.ListarCuentas();
            ValidacionesIngreso(ingreso);
            if (!ModelState.IsValid) return View("Ingresar");
            cuentaService.Ingresar(ingreso);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Gastar()
        {
            ViewBag.cuentas = cuentaService.ListarCuentas();
            return View();
        }

        [HttpPost]
        public ActionResult Gastar(Gasto gasto)
        {
            ViewBag.cuentas = cuentaService.ListarCuentas();
            ValidacionesGasto(gasto);
            if (!ModelState.IsValid) return View("Gastar");
            cuentaService.Gastar(gasto);
            return RedirectToAction("Index");
        }

        private void Validaciones(Cuenta cuenta)
        {
            if (string.IsNullOrEmpty(cuenta.Nombre))
            {
                ModelState.AddModelError("Nombre", "Nombre obligatorio");
            }

            if (cuenta.Categoria == "")
            {
                ModelState.AddModelError("Categoria", "Categoria obligatoria");
            }
            if (cuenta.Moneda == "")
            {
                ModelState.AddModelError("Moneda", "Escoja una Moneda para la cuenta");
            }

            if (cuenta.Saldo <= 0)
            {
                ModelState.AddModelError("SaldoInicial", "Saldo Inicial obligatorio");
            }
        }

        private void ValidacionesIngreso(Ingreso ingreso)
        {
            if (string.IsNullOrEmpty(ingreso.Descripcion))
            {
                ModelState.AddModelError("Descripcion", "Descripcion obligatoria");
            }

            if (ingreso.Monto <= 0)
            {
                ModelState.AddModelError("Monto", "Monto obligatorio");
            }

            if (ingreso.CuentaId <= 0)
            {
                ModelState.AddModelError("Cuenta", "Cuenta obligatorio");
            }
        }

        private void ValidacionesGasto(Gasto gasto)
        {
            if (string.IsNullOrEmpty(gasto.Descripcion))
            {
                ModelState.AddModelError("Descripcion", "Descripcion obligatoria");
            }

            if (gasto.Monto <= 0)
            {
                ModelState.AddModelError("Monto", "Monto obligatorio");
            }

            if (gasto.CuentaId <= 0)
            {
                ModelState.AddModelError("Cuenta", "Cuenta obligatorio");
            }
        }

    }
}
