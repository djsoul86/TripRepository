using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Viajeros.DA;

namespace Viajeros.Services
{
    public class ViajeroService: IViajerosService
    {
        private readonly IMapper _mapper;
        private readonly IViajerosRepository _repo;

        public ViajeroService(IViajerosRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ViajerosDto> CreateAsync(ViajerosRequestDto dto)
        {
            var entity = _mapper.Map<ViajerosRequestDto, Viajero>(dto);
            var result = await _repo.CreateAsync(entity);
            var res = await _repo.GetAsync(result.Id);
            return _mapper.Map<Viajero, ViajerosDto>(res);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetAsync(id);
            await _repo.DeleteAsync(entity);
            return true;
        }

        public async Task<ViajerosDto> GetAsync(int id)
        {
            return _mapper.Map<Viajero, ViajerosDto>(await _repo.GetAsync(id));
        }


        public async Task<ViajerosDto> UpdateAsync(int id, ViajerosRequestDto dto)
        {
            var entity = await _repo.GetAsync(id);
            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
            return _mapper.Map<Viajero, ViajerosDto>(entity);
        }

        public async Task<IList<ViajerosDto>> GetViajeros()
        {
            return _mapper.Map<IList<Viajero>, IList<ViajerosDto>>(await _repo.GetListAsync());

        }
    }
}
