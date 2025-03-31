using Amore.Business.Helpers.DTOs.Location;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var location = await _locationService.GetAllAsync();
            return Ok(location);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var location = await _locationService.GetByIdAsync(id);
                return Ok(location);
            }
            catch (LocationNotFoundException ex)
            {
                throw new LocationNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateLocationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var location =await _locationService.CreateAsync(dto);
                return Ok(location);
            }
            catch (LocationCannotBeCreated ex)
            {
                throw new LocationCannotBeCreated(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateLocationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _locationService.UpdateAsync(dto);
                return NoContent();
            }
            catch (LocationCannotBeUpdate ex)
            {
                throw new LocationCannotBeUpdate(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _locationService.RemoveAsync(id);
                return NoContent();
            }
            catch (LocationCannnotBeRemove ex)
            {
                throw new LocationCannnotBeRemove(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

    }
}
