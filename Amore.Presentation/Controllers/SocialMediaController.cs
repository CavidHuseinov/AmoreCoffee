using Amore.Business.Helpers.DTOs.SocialMedia;
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

    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var socialmedia = await _socialMediaService.GetAllAsync();
            return Ok(socialmedia);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var socialmedia = await _socialMediaService.GetByIdAsync(id);
                return Ok(socialmedia);
            }
            catch (SocialMediaNotFoundException ex)
            {
                throw new SocialMediaNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateSocialMediaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _socialMediaService.CreateAsync(dto);
                return Ok();
            }
            catch (SocialMediaCannotBeCreated ex)
            {
                throw new SocialMediaCannotBeCreated(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateSocialMediaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _socialMediaService.UpdateAsync(dto);
                return NoContent();
            }
            catch (SocialMediaCannotBeUpdate ex)
            {
                throw new SocialMediaCannotBeUpdate(ex.Message);
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
                await _socialMediaService.RemoveAsync(id);
                return NoContent();
            }
            catch (SocialMediaCannotBeRemove ex)
            {
                throw new SocialMediaCannotBeRemove(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
