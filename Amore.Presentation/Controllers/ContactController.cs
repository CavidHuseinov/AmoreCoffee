using Amore.Business.Helpers.DTOs.ContactForm;
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
    public class ContactController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;

        public ContactController(IEmailService emailService, INotificationService notificationService)
        {
            _emailService = emailService;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitComment([FromForm]ContactFormDto model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Rəyiniz göndərilmədi");
            }
            try
            {
                string body = $"İstifadəçi: {model.Name} ({model.Email})\n\nRəy: {model.Comment}";
                await _emailService.SendEmailAsync("Cavidrh-ab107@code.edu.az", "Yeni Rəy Gəldi", body, model.Email, model.Name, model.Comment);
                return Ok("Rəy uğurla göndərildi.");
            }
            catch (ContactFormNotFoundException ex)
            {
                throw new ContactFormNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetUnreadNotifications([FromQuery] int limit = 30)
        {
            try
            {
                var notifications = await _notificationService.GetUnreadNotificationsAsync(limit);

                var notificationDtos = notifications.Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    Email = n.Email,
                    Comment = n.Comment,
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt
                }).ToList();

                return Ok(notificationDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir xəta yarandı: {ex.Message}");
            }
        }
        [HttpPost("mark-read/{id}")]
        public async Task<IActionResult> MarkNotificationAsRead(Guid id)
        {
            try
            {
                await _notificationService.MarkNotificationAsReadAsync(id);
                return Ok("Bildiriş uğurla oxundu");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir xəta yarandı: {ex.Message}");
            }
        }


    }
}
