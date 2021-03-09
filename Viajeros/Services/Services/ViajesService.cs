using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Viajeros.DA;
using Viajeros.Services;

namespace Viajes.Services
{
    public class ViajesService : IViajesService
    {
        private readonly IMapper _mapper;
        private readonly IViajesRepository _repo;

        public ViajesService(IViajesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ViajesDto> CreateAsync(ViajesRequestDto dto)
        {
            var entity = _mapper.Map<ViajesRequestDto, Viaje>(dto);
            var result = await _repo.CreateAsync(entity);
            var res = await _repo.GetAsync(result.Id, "Origen", "Destino");
            return _mapper.Map<Viaje, ViajesDto>(res);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetAsync(id);
            await _repo.DeleteAsync(entity);
            return true;
        }

        public async Task<ViajesDto> GetAsync(int id)
        {
            return _mapper.Map<Viaje, ViajesDto>(await _repo.GetAsync(id));
        }


        public async Task<ViajesDto> UpdateAsync(int id, ViajesRequestDto dto)
        {
            var entity = await _repo.GetAsync(id);
            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
            return _mapper.Map<Viaje, ViajesDto>(entity);
        }

        public async Task<IList<ViajesDto>> GetViaje()
        {
            return _mapper.Map<IList<Viaje>, IList<ViajesDto>>(await _repo.GetListAsync("Origen","Destino"));

        }

    }
}
