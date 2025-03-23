using Amore.Business.Helpers.DTOs.Slogan;
using Amore.Business.Helpers.DTOs.Slogan;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Implementations;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class SloganController : ControllerBase
    {
        private readonly ISloganService _sloganService;

        public SloganController(ISloganService sloganService)
        {
            _sloganService = sloganService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var slogan = await _sloganService.GetAllAsync();
            return Ok(slogan);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var slogan = await _sloganService.GetByIdAsync(id);
                return Ok(slogan);
            }
            catch (SloganNotFoundException ex)
            {
                throw new SloganNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSloganDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _sloganService.CreateAsync(dto);
                return Ok();
            }
            catch (SloganCannotBeCreated ex)
            {
                throw new SloganCannotBeCreated(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateSloganDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _sloganService.UpdateAsync(dto);
                return NoContent();
            }
            catch (SloganCannotBeUpdate ex)
            {
                throw new SloganCannotBeUpdate(ex.Message);
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
                await _sloganService.RemoveAsync(id);
                return NoContent();
            }
            catch (SloganCannotBeRemove ex)
            {
                throw new SloganCannotBeRemove(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
