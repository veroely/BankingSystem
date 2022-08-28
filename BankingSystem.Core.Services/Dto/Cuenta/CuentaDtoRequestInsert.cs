using System;

namespace BankingSystem.Core.Services.Dto.Cuenta
{
    public class CuentaDtoRequestInsert
    {
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoDisponible { get; set; }
        public int IdCliente { get; set; }
    }
}
