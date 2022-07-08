using System;
using System.Collections.Generic;
using System.Linq;
using EFinal_N00194025.DB;
using EFinal_N00194025.Models;

namespace EFinal_N00194025.Servicios
{
    public interface ICuentaService
    {
        
        public List<Cuenta> ListarCuentas();
        public List<Gasto> ListarGastos();
        public List<Ingreso> ListarIngresos();

        public double Gastostotales(List<Gasto> gastos);

        public double IngresosTotales(List<Ingreso> ingresos);

        public double SaldoTotal(List<Cuenta> cuentas);

        void CrearCuenta(Cuenta cuenta);
        void Gastar(Gasto gasto);
        void Ingresar(Ingreso ingreso);

    }
    public class CuentaService : ICuentaService
    {
        AppFinalContext context;
        public CuentaService(AppFinalContext context)
        {
            this.context = context;
        }

        public CuentaService()
        {
        }

        public void CrearCuenta(Cuenta cuenta)
        {
            context.Cuentas.Add(cuenta);
            context.SaveChanges();
        }


        public List<Cuenta> ListarCuentas()
        {
            return context.Cuentas.ToList();
        }

        public List<Gasto> ListarGastos()
        {
            return context.Gastos.ToList();
        }

        public List<Ingreso> ListarIngresos()
        {
            return context.Ingresos.ToList();
        }

        public void Gastar(Gasto gasto)
        {
            var cuenta = context.Cuentas.Where(o => o.Id == gasto.CuentaId).FirstOrDefault();
            if (cuenta.Saldo > gasto.Monto)
            {
                cuenta.Saldo = cuenta.Saldo - gasto.Monto;
                var fecha = DateTime.Now;
                gasto.Fecha = fecha;
                context.Gastos.Add(gasto);
                context.SaveChanges();
            }
        }

        public void Ingresar(Ingreso ingreso)
        {
            var cuenta = context.Cuentas.Where(o => o.Id == ingreso.CuentaId).FirstOrDefault();
            cuenta.Saldo = cuenta.Saldo + ingreso.Monto;
            var fecha = DateTime.Now;
            ingreso.Fecha = fecha;
            context.Ingresos.Add(ingreso);
            context.SaveChanges();

        }

        public double Gastostotales(List<Gasto> gastos)
        {
            double total = 0;
            foreach (var gasto in gastos)
            {
                total += gasto.Monto;
            }
            return total;
        }

        public double IngresosTotales(List<Ingreso> ingresos)
        {
            double total = 0;
            foreach (var ingreso in ingresos)
            {
                total += ingreso.Monto;
            }
            return total;
        }

        public double SaldoTotal(List<Cuenta>cuentas)
        {
            double total = 0;
            foreach (var cuenta in cuentas)
            {
                total += cuenta.Saldo;
            }
            return total;

        }
    }
}