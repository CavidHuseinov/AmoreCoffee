using Amore.Business.Helpers.DTOs.Promocode;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Implementations;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class PromocodeController : ControllerBase
    {
        private readonly IPromocodeService _promocodeService;

        public PromocodeController(IPromocodeService promocodeService)
        {
            _promocodeService = promocodeService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var promocode = await _promocodeService.GetAllAsync();
            return Ok(promocode);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromocodeById(Guid id)
        {
            try
            {
                var promocode = await _promocodeService.GetByIdAsync(id);
                return Ok(promocode);
            }
            catch (PromocodeNotFoundException ex)
            {
                throw new PromocodeNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePromocode([FromForm] CreatePromocodeDto dto)
        {
            //try
            //{
            var promocode = await _promocodeService.CreateAsync(dto);
            return Ok(promocode);
            //}
            //catch(PromocodeCannotBeCreated ex)
            //{
            //    throw new PromocodeCannotBeCreated(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message });
            //}
        }

        
        [HttpPost("validate")]
        public async Task<IActionResult> ValidatePromocode([FromBody] string code)
        {
            var isValid = await _promocodeService.ValidatePromocodeAsync(code);
            return Ok(new { isValid });
        }
        [HttpPost("use-promocode")]
        public async Task<IActionResult> UsePromocode(string userId, string promocodeCode)
        {
            try
            {
                var promocodeDto = await _promocodeService.UsePromocodeAsync(userId, promocodeCode);

                return Ok(promocodeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
