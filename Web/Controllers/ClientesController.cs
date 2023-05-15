using Microsoft.AspNetCore.Mvc;
using Serilog;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ObtenerClientesService _obtenerClientesService;
        private readonly BuscarClientesService _buscarClientesService;
        private readonly AgregarClientesService _agregarClientesService;
        private readonly ModificarClientesService _modificarClientesService;
        private readonly EliminarClientesService _eliminarClientesService;

        public ClientesController(ObtenerClientesService obtenerClientesService, BuscarClientesService buscarClientesService,
                                  AgregarClientesService agregarClientesService, ModificarClientesService modificarClientesService, 
                                  EliminarClientesService eliminarClientesService)
        {
            _obtenerClientesService = obtenerClientesService;
            _buscarClientesService = buscarClientesService;
            _agregarClientesService = agregarClientesService;
            _modificarClientesService = modificarClientesService;
            _eliminarClientesService = eliminarClientesService;
        }

        // GET: api/Clientes
        [HttpGet]
        [Route("ObtenerClientes")]
        public IActionResult GetClientes()
        {
            Log.Information("Hola");
            var clientes = _obtenerClientesService.Execute();
            
            if (clientes is null)
                return NotFound("No hay clientes");
            
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        [Route("BuscarCliente")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _buscarClientesService.Execute(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("ModificarCliente")]
        public Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            var clienteModificado = _modificarClientesService.Execute(id, cliente);
    
            //await _clienteService.SaveChangesAsync();
            
            return clienteModificado;
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AgregarCliente")]
        public Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var clienteNuevo = _agregarClientesService.Execute(cliente);
            //_clienteService.SaveChangesAsync();

            return clienteNuevo;
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        [Route("EliminarCliente")]
        public Task<IActionResult> DeleteCliente(int id)
        {
            var clienteEliminado = _eliminarClientesService.Execute(id);
            
            //await _clienteService.SaveChangesAsync();

            return clienteEliminado;
        }
    }
}
