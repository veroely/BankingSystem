using System;

namespace BankingSystem.Core.Services.Dto.Movimiento
{
    public class MovimientoDto
    {
        public int IdMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCuenta { get; set; }
    }
}
