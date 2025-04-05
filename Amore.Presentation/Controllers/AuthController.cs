using System.Diagnostics;
using Amore.Business.Helpers.DTOs.User;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Implementations;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var user = await _userService.GetAllAsync();
            return Ok(user);
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userProfile = await _userService.GetByIdAsync();
            return Ok(userProfile);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm]RegisterDto dto)
        {
            try
            {
                await _userService.RegisterAsync(dto);
                return Ok();
            }
            catch (RegisterNotFoundException ex)
            {
                throw new RegisterNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login ([FromForm]LoginDto dto)
        {
            try
            {
                var token = await _userService.LoginAsync(dto);
                return Ok(token);
            }
            catch(LoginNotFoundException ex)
            {
                throw new LoginNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword([FromForm]ForgotPasswordDto dto)
        {
            try
            {
                await _userService.ForgotPasswordAsync(dto);
                return Ok(new {message = "Şifrəni sıfırlamaq üçün məlumat göndərildi e-posta qutunuzu yoxlayın"});
            }
            catch(ForgotPasswordNotFoundException ex)
            {
                throw new ForgotPasswordNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordDto dto)
        {
            try
            {
                await _userService.ResetPasswordAsync(dto);
                return Ok(new {message="Şifrəniz yeniləndi."});
            }
            catch(ResetPasswordNotFoundException ex)
            {
                throw new ResetPasswordNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Admin 

        //[Authorize(Roles = "Admin")]
        [HttpPost("Register-Admin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] RegisterDto dto)
        {
            try
            {
                await _userService.RegisterAdminAsync(dto);
                return Ok(new { message = "Admin uğurla yaradıldı" });
            }
            catch (RegisterNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPost("Update-Own-Photo-In-Cabinet")]
        
        public async Task<IActionResult> UpdateProfileAsync (ProfileUpdateDto dto)
        {
            try
            {
                await _userService.UpdateAsync(dto);
                return NoContent();
            }
            catch(ProfileUpdateCannotBeUpdate ex)
            {
                throw new ProfileUpdateCannotBeUpdate(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
