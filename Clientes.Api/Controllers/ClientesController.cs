﻿using Microsoft.AspNetCore.Mvc;
using Serilog;
using Clientes.Api.Services;
using Clientes.Api.DTO;

namespace Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // GET: api/Clientes
        [HttpGet]
        public IActionResult GetClients()
        {
            Log.Information("Hola");
            var clientes = _clientesService.Get();

            if (clientes is null)
                return NotFound("No hay clientes");

            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public IActionResult FindClient(int id)
        {
            var cliente = _clientesService.FindById(id);

            if (cliente is null)
                return NotFound("Id inexistente");

            return Ok(cliente);
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateClient(ClienteRequestDTO request)
        {
            var clienteNuevo = _clientesService.Create(request);

            if (clienteNuevo is null)
                return BadRequest("Error al insertar el cliente");

            return Ok(clienteNuevo);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult ModifyClient(int requestId, ClienteRequestDTO requestData)
        {
            var clienteModificado = _clientesService.Update(requestId, requestData);

            if (clienteModificado is null)
                return NotFound($"Id {requestId} inexistente");

            return Ok(clienteModificado);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var clienteEliminado = _clientesService.Delete(id);

            if (clienteEliminado is null)
                return NotFound($"Id {id} inexistente");

            return Ok(clienteEliminado);
        }
    }
}
