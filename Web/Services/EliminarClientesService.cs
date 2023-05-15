﻿using Web.Infrastructure.Repositories;
using Web.Infrastructure;

namespace Web.Services
{
    public class EliminarClientesService
    {
        private readonly ClientesRepository _clienteRepository;
        private readonly ILogger<EliminarClientesService> _logger;
        private readonly IMapper _mapper;

        public EliminarClientesService(ClientesRepository clienteRepository, ILogger<EliminarClientesService> logger, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public Task Execute(int id)
        {
            //Log.Information($"VC | {this.GetType().Name} => Inicio de ejecución por {input.Usuario}...");
            //
            //if (input is null || string.IsNullOrWhiteSpace(input.FolderPath))
            //{
            //    Log.Warning($"VC | {this.GetType().Name} => Entrada nula");
            //    _outputPort.WriteError("Entrada nula.");
            //    return Task.CompletedTask;
            //}

            return Task.CompletedTask;
        }
    }
}
