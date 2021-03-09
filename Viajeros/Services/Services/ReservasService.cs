using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Viajeros.DA;

namespace Viajeros.Services
{
    public class ReservasService : IReservasService
    {
        private readonly IMapper _mapper;
        private readonly IReservasRepository _repo;

        public ReservasService(IReservasRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ReservaDto> CreateAsync(ReservaRequestDto dto)
        {
            var entity = _mapper.Map<ReservaRequestDto, Reserva>(dto);
            var result = await _repo.CreateAsync(entity);
            var res = await _repo.GetAsync(result.Id, "Viajero", "Viaje.Origen", "Viaje.Destino");
            return _mapper.Map<Reserva, ReservaDto>(res);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetAsync(id);
            await _repo.DeleteAsync(entity);
            return true;
        }


        public async Task<IList<ReservaDto>> GetReservas()
        {
            return _mapper.Map<IList<Reserva>, IList<ReservaDto>>(await _repo.GetListAsync("Viajero", "Viaje.Origen", "Viaje.Destino"));

        }
    }
}
