using Amore.Business.Helpers.DTOs.Product;
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

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var product = await _productService.GetAllAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return Ok(product);
            }
            catch (ProductNotFoundException ex)
            {
                throw new ProductNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]CreateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _productService.CreateAsync(dto);
                return Ok();
                return Ok();
            }
            catch (ProductCannotBeCreated ex)
            {
                throw new ProductCannotBeCreated(ex.Message);
            }
            catch (Exception ex)
            { return StatusCode(StatusCodes.Status404NotFound, ex.Message); }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _productService.UpdateAsync(dto);
                return NoContent();
            }
            catch (ProductCannotBeUpdate ex)
            {
                throw new ProductCannotBeUpdate(ex.Message);
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
                await _productService.RemoveAsync(id);
                return NoContent();
            }
            catch (ProductCannotBeRemove ex)
            {
                throw new ProductCannotBeRemove(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
