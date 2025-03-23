using System.Security.Cryptography.Xml;
using Amore.Business.Helpers.DTOs.Slider;
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

    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var slider = await _sliderService.GetAllAsync();
            return Ok(slider);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var slider = await _sliderService.GetByIdAsync(id);
                return Ok(slider);
            }
            catch (SliderNotFoundException ex)
            {
                throw new SliderNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSliderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var slider = await _sliderService.CreateAsync(dto);
                return Ok(slider);
            }
            catch (SliderCannotBeCreated ex)
            {
                throw new SliderCannotBeCreated(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update ([FromForm] UpdateSliderDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _sliderService.UpdateAsync(dto);
                return NoContent();
            }
            catch(SliderCannotBeUpdate ex)
            {
                throw new SliderCannotBeUpdate(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _sliderService.RemoveAsync(id);
                return NoContent();
            }
            catch(SliderCannotBeRemove ex)
            {
                throw new SliderCannotBeRemove(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
