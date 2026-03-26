using DoorBell.Application.Usecases.CameraUsecase;
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
        public CameraController(DetectUsecase detectUsecase, DetectPersonUsecase detectPersonUsecase)
        {
            _detectUsecase = detectUsecase;
            _detectPersonUsecase = detectPersonUsecase;
        }

        [HttpPost("detect")]
        public async Task<IActionResult> Detect([FromForm] IFormFile file, [FromForm] string apiKey)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file");

            Console.WriteLine("Received image");

            //var path = Path.Combine("uploads", $"{Guid.NewGuid()}.jpg");
            //Directory.CreateDirectory("uploads");

            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    await file.CopyToAsync(stream);
            //}

            byte[] imageBytes;
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }

            bool hasPeople = _detectPersonUsecase.Execute(imageBytes);

            var result = await _detectUsecase.Execute(apiKey, hasPeople);

            return Ok(new
            {
                hasPeople = hasPeople
            });
        }
    }
}
