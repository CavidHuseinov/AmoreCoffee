using System.Runtime.CompilerServices;
using Amore.Business.Helpers.DTOs.UploadFile;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileService _fileUploadService;

        public UploadFileController(IUploadFileService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] CreateUploadFileDto fileUploadDto)
        {

            try
            {
                GetUploadFileDto fileResponse = await _fileUploadService.UploadFileAsync(fileUploadDto);
                return Ok(fileResponse);
            }
            catch (FileUploadNotFoundException ex)
            {
                throw new FileUploadNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
