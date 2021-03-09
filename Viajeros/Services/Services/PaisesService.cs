using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Viajeros.DA;

namespace Viajeros.Services
{
    public class PaisesService : IPaisesService
    {
        private readonly IMapper _mapper;
        private readonly IPaisesRepository _repo;

        public PaisesService(IPaisesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IList<PaisDto>> GetAllPaises()
        {
            return _mapper.Map<IList<Pais>, IList<PaisDto>>(await _repo.GetListAsync());
        }
    }
}
