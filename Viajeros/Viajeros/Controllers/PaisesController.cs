using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/[controller]")]
    public class PaisesController : Controller
    {
        private readonly IPaisesService _service;

        public PaisesController(
            IPaisesService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Paises List.
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("GetPaisesList")]
        [ProducesResponseType(typeof(List<PaisDto>), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> GetPaisesList()
        {
            try
            {
                var result = await _service.GetAllPaises();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
    }
}
