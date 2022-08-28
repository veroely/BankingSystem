using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core.Model.Entities
{
    public class ReporteMovimientosCliente
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public string EstadoCuenta { get; set; }
        public decimal Movimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
