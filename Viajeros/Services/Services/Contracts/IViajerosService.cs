using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viajeros.Services
{
    public interface IViajerosService
    {
        /// <summary>
        /// Creates a new Viajero.
        /// </summary>
        /// <param name="dto">Viajero to create</param>
        Task<ViajerosDto> CreateAsync(ViajerosRequestDto dto);
        /// <summary>
        /// Get a Viajero By Given Id.
        /// </summary>
        /// <param name="id">Auditor to search</param>
        Task<ViajerosDto> GetAsync(int id);
        /// <summary>
        /// Delete a Viajero by given id.
        /// </summary>
        /// <param name="id">Viajero id to delete</param>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// Update a Viajero.
        /// </summary>
        /// <param name="dto">Viajero to update</param>
        Task<ViajerosDto> UpdateAsync(int id, ViajerosRequestDto dto);
        /// <summary>
        /// Get list of all viajeros.
        /// </summary>
        Task<IList<ViajerosDto>> GetViajeros();
    }
}
