using Amore.Business.Helpers.DTOs.HeadBanner;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Context;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class HeadBannersController : ControllerBase
    {
        private readonly IHeadBannerService _headBannerService;

        public HeadBannersController(IHeadBannerService headBannerService)
        {
            _headBannerService = headBannerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var headBanners = await _headBannerService.GetAllAsync();
            return Ok(headBanners);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var headBanner = await _headBannerService.GetById(id);
                return Ok(headBanner);
            }
             catch (HeadBannerNotFoundException ex)
            {
                throw new HeadBannerNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateHeadBannerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var banner = await _headBannerService.Create(dto);
                return Ok(banner);
            }
            catch(HeadBannerCannotBeCreated ex)
            {
                throw new HeadBannerCannotBeCreated(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateHeadBannerDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _headBannerService.Update(dto);
                return NoContent();
            }
            catch (HeadBannerCannotBeUpdate ex)
            {
                throw new HeadBannerCannotBeUpdate(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                await _headBannerService.Remove(id);
                return NoContent();
            }
            catch (HeadBannerCannotBeRemove ex)
            {
                throw new HeadBannerCannotBeRemove();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

        }
    }
}
