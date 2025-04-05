using Amore.Business.Helpers.DTOs.Variant;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class VariantController : ControllerBase
    {
        private readonly IVariantService _variantService;

        public VariantController(IVariantService variantService)
        {
            _variantService = variantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var variant = await _variantService.GetAllAsync();
            return Ok(variant);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            try
            {
                var variant = await _variantService.GetByIdAsync(Id);
                return Ok(variant);
            }
            catch (VariantNotFoundException ex)
            {
                throw new VariantNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateVariantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var variant = await _variantService.CreateAsync(dto);
                return Ok(variant);
            }
            catch (VariantCannotBeCreate ex)
            {
                throw new VariantCannotBeCreate(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateVariantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _variantService.UpdateAsync(dto);
                return NoContent();
            }
            catch (VariantCannotBeUpdate ex)
            {
                throw new VariantCannotBeUpdate(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _variantService.RemoveAsync(id);
                return Ok();
            }
            catch (VariantCannotBeDelete ex)
            {
                throw new VariantCannotBeDelete(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
