using System;

namespace BankingSystem.Core.Model.Entities
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha {get;set;}
        public virtual Cuenta Cuenta { get; set; }
        public int IdCuenta { get; set; }
    }
}
