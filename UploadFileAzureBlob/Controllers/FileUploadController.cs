using Microsoft.AspNetCore.Mvc;
using UploadFileAzureBlob.Service;

namespace UploadFileAzureBlob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public FileUploadController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public IActionResult Get()
        {
            return Ok("file upload api running");
        }

        //IFormFile retrieves image from form
        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            _storageService.Upload(file);
            return Ok(new {Message = "Archivo subido a la nube", file});
        }
    }
}
