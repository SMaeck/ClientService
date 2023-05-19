using AutoMapper;
using Clientes.Api.DTO;
using Clientes.Infrastructure.Entities;
using Clientes.Infrastructure.Repositories;

namespace Transferencias.App.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteRequestDTO, Cliente>();
            CreateMap<Cliente, ClienteResponseDTO>();
                //.ForMember(dest => dest.cuentaOrigen, opt => opt.MapFrom(src => $"{src.cbuOrigen.Substring(3, 4)}-{src.cbuOrigen.Substring(8, 13)}"))
                //.ForMember(dest => dest.cuentaDestino, opt => opt.MapFrom(src => $"{src.cbuDestino.Substring(3, 4)}-{src.cbuDestino.Substring(8, 13)}"));
        }
    }
}

