using AutoMapper;
using System.Text.Json;
using Clientes.Api.DTO;
using Clientes.Infrastructure.Entities;
using Clientes.Infrastructure.Repositories;

namespace Clientes.Api.Services
{
    public class ClientesService : IService<ClienteRequestDTO, ClienteResponseDTO>
    {
        private readonly ClientesRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientesService> _logger;

        public ClientesService(ClientesRepository clienteRepository, IMapper mapper, ILogger<ClientesService> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public ClienteResponseDTO Create(ClienteRequestDTO request)
        {
            var data = _mapper.Map<Cliente>(request);
            var cliJson = JsonSerializer.Serialize(data);

            try
            {
                Cliente cliente = _clienteRepository.Add(data);
                _logger.LogInformation($"Cliente dado de alta: {cliJson}");

                return _mapper.Map<ClienteResponseDTO>(cliente);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al insertar el cliente: {cliJson}");
                throw;
            }
        }

        public List<ClienteResponseDTO> Get()
        {
            try
            {
                var clientes = _clienteRepository.GetClientes();
                _logger.LogInformation($"Se obtuvieron todos los Clientes: {JsonSerializer.Serialize(clientes)}");

                return _mapper.Map<List<ClienteResponseDTO>>(clientes);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al obtener todos los clientes");
                throw;
            }
        }

        public ClienteResponseDTO FindById(int id)
        {
            try
            {
                var cliente = _clienteRepository.FindById(id);

                if (cliente is null)
                    return new ClienteResponseDTO();

                return _mapper.Map<ClienteResponseDTO>(cliente);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al obtener el cliente con el id: {id}");
                throw;
            }
        }

        public ClienteResponseDTO Update(int id, ClienteRequestDTO request)
        {
            try
            {
                var cliente = _clienteRepository.FindById(id);

                if (cliente is null)
                    return null;

                var data = _mapper.Map<Cliente>(request);

                if (!string.IsNullOrEmpty(data.Nombre) && cliente.Nombre != data.Nombre) cliente.Nombre = data.Nombre;
                if (!string.IsNullOrEmpty(data.Apellido) && cliente.Apellido != data.Apellido) cliente.Apellido = data.Apellido;
                if (!string.IsNullOrEmpty(data.TipoDocumento) && cliente.TipoDocumento != data.TipoDocumento) cliente.TipoDocumento = data.TipoDocumento;
                if (data.NroDocumento > 0 && cliente.NroDocumento != data.NroDocumento) cliente.NroDocumento = data.NroDocumento;
                if (!string.IsNullOrEmpty(data.Cuil) && cliente.Cuil != data.Cuil) cliente.Cuil = data.Cuil;
                if (cliente.EsEmpleadoBna != data.EsEmpleadoBna) cliente.EsEmpleadoBna = data.EsEmpleadoBna;
                if (!string.IsNullOrEmpty(data.PaisOrigen) && cliente.PaisOrigen != data.PaisOrigen) cliente.PaisOrigen = data.PaisOrigen;

                var clienteModificado = _clienteRepository.Update(cliente);

                return _mapper.Map<ClienteResponseDTO>(clienteModificado);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al actualizar el cliente con el id: {id}");
                throw;
            }
        }

        public ClienteResponseDTO Delete(int id)
        {
            try
            {
                var cliente = _clienteRepository.FindById(id);

                if (cliente is null)
                    return null;

                _clienteRepository.Delete(cliente);

                return _mapper.Map<ClienteResponseDTO>(cliente);
            }
            catch (Exception)
            {
                _logger.LogError($"Error al eliminar el cliente con el id: {id}");
                throw;
            }
        }
    }
}
