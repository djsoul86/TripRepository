using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Viajeros.Services;
using Viajes.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Viajes.API.Controllers
{
    [Route("api/[controller]")]
    public class ViajesController : Controller
    {
        private readonly IViajesService _service;

        public ViajesController(
            IViajesService service)
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
        [ProducesResponseType(typeof(ViajesDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> Create([FromBody] ViajesRequestDto dto)
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
        [HttpPut("Update")]
        [ProducesResponseType(typeof(ViajesDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> Update(int id, [FromBody] ViajesRequestDto dto)
        {

            try
            {
                var result = await _service.UpdateAsync(id, dto);
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
        [HttpGet("GetViajesList")]
        [ProducesResponseType(typeof(List<ViajesDto>), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult> GetViajesList()
        {
            try
            {
                var result = await _service.GetViaje();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
    }
}