using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viajeros.Services
{
    public interface IPaisesService
    {
        /// <summary>
        /// Get list of all Viaje.
        /// </summary>
        Task<IList<PaisDto>> GetAllPaises();
    }
}
