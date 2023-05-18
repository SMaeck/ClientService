﻿namespace Clientes.Api.DTO
{
    public class ClienteRequestDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cuil { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public bool? EsEmpleadoBna { get; set; }
        public string? PaisOrigen { get; set; }
    }
}
