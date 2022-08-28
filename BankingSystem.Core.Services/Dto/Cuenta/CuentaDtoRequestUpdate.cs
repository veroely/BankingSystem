using System;

namespace BankingSystem.Core.Services.Dto.Cuenta
{
    public class CuentaDtoRequestUpdate
    {
        public decimal SaldoDisponible { get; set; }
        public string Estado { get; set; }
    }
}
