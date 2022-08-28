using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Services.Dto.Cuenta;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentasController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<IActionResult> GetByIdCliente(int idCliente)
        {
            List<CuentaDtoResponse> cuentas = await _cuentaService.getByIdCliente(idCliente);
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CuentaDtoResponse cuentaDto = await _cuentaService.getByIdCuenta(id);
            return Ok(cuentaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CuentaDtoRequestInsert cuentaDto)
        {
            try
            {
                await _cuentaService.addCuenta(cuentaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CuentaDtoRequestUpdate cuentaDto)
        {
            try
            {
                await _cuentaService.updateCuenta(id, cuentaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
