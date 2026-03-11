using BlobImageUploadApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlobImageUploadApi.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        private readonly BlobService _blobService;

        public UploadController(BlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _blobService.UploadAsync(file);
            return Ok("File uploaded successfully");
        }
    }
}
