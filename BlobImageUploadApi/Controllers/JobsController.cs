using BlobImageUploadApi.Requests;
using BlobImageUploadApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlobImageUploadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly QueueService _queueService;

        public JobsController(QueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpPost]
        public IActionResult PostJob([FromBody] JobRequest request)
        {
            _queueService.EnqueueMessage(request.Task);
            return Ok( new
            {
                Message = "Job queued successfully"
            });
        }
    }
}
