using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Services.Dto.Cliente;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientesController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ClienteDtoResponse> response = await _clientService.getAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ClienteDtoResponse response = await _clientService.getById(id);
            return Ok(response);
        }

        [HttpGet("porIdentificacion/{identificacion}")]
        public async Task<IActionResult> GetByIdentificacion(string identificacion)
        {
            ClienteDtoResponse response = await _clientService.getByIdentificacion(identificacion);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDtoRequestInsert cliente)
        {
            try
            {
                await _clientService.addClient(cliente);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteDtoRequestUpdate cliente)
        {
            try
            {
                await _clientService.updateClient(id, cliente);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clientService.deleteCliente(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
