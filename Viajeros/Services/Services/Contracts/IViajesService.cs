using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viajeros.DA;
using Viajeros.Services;

namespace Viajes.Services
{
    public interface IViajesService
    {
        /// <summary>
        /// Creates a new Viaje.
        /// </summary>
        /// <param name="dto">Viajero to create</param>
        Task<ViajesDto> CreateAsync(ViajesRequestDto dto);
        /// <summary>
        /// Get a Viaje By Given Id.
        /// </summary>
        /// <param name="id">Auditor to search</param>
        Task<ViajesDto> GetAsync(int id);
        /// <summary>
        /// Delete a Viaje by given id.
        /// </summary>
        /// <param name="id">Viajero id to delete</param>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// Update a Viaje.
        /// </summary>
        /// <param name="dto">Viaje to update</param>
        Task<ViajesDto> UpdateAsync(int id, ViajesRequestDto dto);
        /// <summary>
        /// Get list of all Viaje.
        /// </summary>
        Task<IList<ViajesDto>> GetViaje();
    }
}
