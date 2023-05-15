using Web.Infrastructure.Repositories;

namespace Web.Services
{
    public class ObtenerClientesService
    {
        private readonly ClientesRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ObtenerClientesService> _logger;

        public ObtenerClientesService(ClientesRepository clienteRepository, ILogger<ObtenerClientesService> logger, IMapper mapper) 
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task Execute()
        {
            //Log.Information($"VC | {this.GetType().Name} => Inicio de ejecución por {input.Usuario}...");
            //
            //if (input is null || string.IsNullOrWhiteSpace(input.FolderPath))
            //{
            //    Log.Warning($"VC | {this.GetType().Name} => Entrada nula");
            //    _outputPort.WriteError("Entrada nula.");
            //    return Task.CompletedTask;
            //}
            var clientes = _clienteRepository.GetClientes();

            return Task.CompletedTask;
        }
    }
}
