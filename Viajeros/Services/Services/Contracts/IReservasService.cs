using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viajeros.Services
{ 
    public interface IReservasService
    {
        /// <summary>
        /// Creates a new Viaje.
        /// </summary>
        /// <param name="dto">Viajero to create</param>
        Task<ReservaDto> CreateAsync(ReservaRequestDto dto);
        /// <summary>
        /// Delete a Viaje by given id.
        /// </summary>
        /// <param name="id">Viajero id to delete</param>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// Get list of all Viaje.
        /// </summary>
        Task<IList<ReservaDto>> GetReservas();
    }
}

