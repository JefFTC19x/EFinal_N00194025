using System;
using System.Collections.Generic;

namespace EFinal_N00194025.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public String Nombre{ get; set; }
        public String Categoria { get; set; }
        public double Saldo { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Ingreso> Ingresos { get; set; }
        public string Moneda { get; set; }

    }
}
