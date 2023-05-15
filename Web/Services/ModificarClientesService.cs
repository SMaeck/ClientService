using Web.Infrastructure.Repositories;
using Web.Infrastructure;
using Web.Models;

namespace Web.Services
{
    public class ModificarClientesService
    {
        private readonly ClientesRepository _clienteRepository;
        private readonly ILogger<ModificarClientesService> _logger;
        private readonly IMapper _mapper;

        public ModificarClientesService(ClientesRepository clienteRepository, ILogger<ModificarClientesService> logger, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task Execute(int id, Cliente cliente)
        {
            return Task.CompletedTask;
        }
    }
}
