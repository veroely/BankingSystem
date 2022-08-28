using System;

namespace BankingSystem.Core.Model.Entities
{
    public class Cuenta
    {
        public Cuenta()
        {
            FechaCreacion = new DateTime();
        }

        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoDisponible { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
    }
}
