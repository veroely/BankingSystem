namespace BankingSystem.Core.Services.Dto.Movimiento
{
    public class MovimientoDtoRequestInsert
    {
        public string NumeroCuenta { get; set; }
        public decimal Valor { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
