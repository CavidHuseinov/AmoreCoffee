
using Amore.Business.Helpers.DTOs.ShippingInfo;
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
    //[Authorize]
    public class ShippingInfoController : ControllerBase
    {
        private readonly IShippingInfoService _shippingInfoService;

        public ShippingInfoController(IShippingInfoService shippingInfoService)
        {
            _shippingInfoService = shippingInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var shippingInfos = await _shippingInfoService.GetAllAsync();
            return Ok(shippingInfos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var shippingInfo = await _shippingInfoService.GetByIdAsync(id);
                return Ok(shippingInfo);
            }
            catch (ShippingInfoException ex)
            {
                throw new ShippingInfoException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateShippingInfoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var shippingInfo = await _shippingInfoService.CreateAsync(dto);
                return Ok(shippingInfo);
            }
            catch (ShippingInfoException ex)
            {
                throw new ShippingInfoException(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
