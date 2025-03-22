using System.Security.Cryptography.Xml;
using Amore.Business.Helpers.DTOs.Logo;
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

    public class LogoController : ControllerBase
    {
        private readonly ILogoService _logoService;

        public LogoController(ILogoService logoService)
        {
            _logoService = logoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var logo = await _logoService.GetAllAsync();
            return Ok(logo);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var logo = await _logoService.GetByIdAsync(id);
                return Ok(logo);
            }
            catch (LogoNotFoundException ex)
            {
                throw new LogoNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateLogoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
               var logo = await _logoService.CreateAsync(dto);
                return Ok(logo);
            }
            catch (LogoCannotBeCreated ex)
            {
                throw new LogoCannotBeCreated(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateLogoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _logoService.UpdateAsync(dto);
                return NoContent();
            }
            catch (LogoCannotBeUpdate ex)
            {
                throw new LogoCannotBeUpdate(ex.Message);
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
                await _logoService.RemoveAsync(id );
                return NoContent();
            }
            catch (LogoCannotBeRemove ex)
            {
                throw new LogoCannotBeRemove(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

    }
}
