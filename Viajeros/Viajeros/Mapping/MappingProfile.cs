using AutoMapper;
using Viajeros.DA;
using Viajeros.Services;

namespace Viajeros.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Viajero, ViajerosDto>();
            CreateMap<ViajerosRequestDto, Viajero>();

            CreateMap<Viaje, ViajesDto>();
            CreateMap<ViajesRequestDto, Viaje>();

            CreateMap<Reserva, ReservaDto>();
            CreateMap<ReservaRequestDto, Reserva>();

            CreateMap<Pais, PaisDto>();
        }
    }
}
