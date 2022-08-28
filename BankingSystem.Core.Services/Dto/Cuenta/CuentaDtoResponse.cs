namespace BankingSystem.Core.Services.Dto.Cuenta
{
    public class CuentaDtoResponse
    {
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoDisponible { get; set; }
        public string Estado { get; set; }
    }
}
