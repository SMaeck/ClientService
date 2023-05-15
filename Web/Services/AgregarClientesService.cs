using Web.Infrastructure.Repositories;
using Web.Infrastructure;
using Web.Models;

namespace Web.Services
{
    public class AgregarClientesService
    {
        private readonly ClientesRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AgregarClientesService> _logger;

        public AgregarClientesService(ClientesRepository clienteRepository, IMapper mapper, ILogger<AgregarClientesService> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task Execute(Cliente cliente)
        {
            return Task.CompletedTask;
        }
    }
}
