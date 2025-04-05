using Amore.Business.Helpers.DTOs.Tag;
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

    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tag = await _tagService.GetAllAsync();
            return Ok(tag);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var tag = await _tagService.GetByIdAsync(id);
                return Ok(tag);
            }
            catch (TagNotFoundException ex)
            {
                throw new TagNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTagDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _tagService.CreateAsync(dto);
                return Ok();
            }
            catch (TagCannotBeCreated ex)
            {
                throw new TagCannotBeCreated(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateTagDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _tagService.UpdateAsync(dto);
                return NoContent();
            }
            catch (TagCannotBeUpdate ex)
            {
                throw new TagCannotBeUpdate(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _tagService.RemoveAsync(id);
                return NoContent();
            }
            catch (TagCannotBeRemove ex)
            {
                throw new TagCannotBeRemove(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
