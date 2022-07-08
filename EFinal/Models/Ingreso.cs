using System;

namespace EFinal_N00194025.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }

        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
