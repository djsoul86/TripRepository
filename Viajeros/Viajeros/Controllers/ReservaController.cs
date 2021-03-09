using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Viajeros.Services;


namespace Viajeros.API
{
    [Route("api/[controller]")]
    public class ReservaController : Controller
    {
        private readonly IReservasService _service;

        public ReservaController(
            IReservasService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new Viajeros.
        /// </summary>
        /// <param name="dto">Lot to create</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(ReservaDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> Create([FromBody] ReservaRequestDto dto)
        {

            try
            {
                var result = await _service.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }


        /// <summary>
        /// Update a Viajeros.
        /// </summary>
        /// <param name="dto">Viajeros to create</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var result = await _service.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Get Lot Viajeros List.
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        [HttpGet("GetReservasList")]
        [ProducesResponseType(typeof(List<ViajerosDto>), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> GetReservasList()
        {
            try
            {
                var result = await _service.GetReservas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
    }
}
