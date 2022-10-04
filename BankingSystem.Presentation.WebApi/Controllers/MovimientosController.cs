using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Services.Dto.Movimiento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        public MovimientosController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpGet("porClienteyCuenta")]
        public async Task<IActionResult> GetMovimientos(int idCliente, string numeroCuenta)
        {
            List<MovimientoDto> movimientoDtos = await _movimientoService.getMovimientosByIdCliente(idCliente, numeroCuenta);
            return Ok(movimientoDtos);
        }

        [HttpGet("reporte/{idCliente}/{fechaDesde}/{fechaHasta}")]
        public async Task<IActionResult> ReporteMovimientos(int idCliente, string fechaDesde, string fechaHasta)
        {
            List<MovimientoReporteDto> movimientoDtos = await _movimientoService.getMovimientosByIdClienteFechas(idCliente, fechaDesde, fechaHasta);
            return Ok(movimientoDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MovimientoDtoRequestInsert movimientoDtoRequestInsert)
        {
            try
            {
                await _movimientoService.addMovimiento(movimientoDtoRequestInsert);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
    }
}
