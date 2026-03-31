using DoorBell.Application.Usecases.CameraUsecase;
using DoorBell.Application.Usecases.DeviceUsecase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        DetectUsecase _detectUsecase;
        DetectPersonUsecase _detectPersonUsecase;
        CheckCameraUseCase _checkPress;
        public CameraController(
            DetectUsecase detectUsecase, 
            DetectPersonUsecase detectPersonUsecase,
            CheckCameraUseCase checkCameraUseCase)
        {
            _detectUsecase = detectUsecase;
            _detectPersonUsecase = detectPersonUsecase;
            _checkPress = checkCameraUseCase;
        }

        [HttpPost("detect")]
        public async Task<IActionResult> Detect([FromForm] DetectRequestDto request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file");

            Console.WriteLine("Received image");

            byte[] imageBytes;
            using (var ms = new MemoryStream())
            {
                await request.File.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }

            bool hasPeople = _detectPersonUsecase.Execute(imageBytes);

            var result = await _detectUsecase.Execute(request.ApiKey, hasPeople);

            return Ok(new
            {
                hasPeople = hasPeople
            });
        }

        [HttpPost("press")]
        public async Task<bool> Press([FromBody] string apiKey)
        {
            return await _checkPress.Execute(apiKey);
        }
    }

    public class DetectRequestDto
    {
        public IFormFile File { get; set; }
        public string ApiKey { get; set; }
    }
}
