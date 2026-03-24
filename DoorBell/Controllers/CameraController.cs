using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        [HttpPost("detect")]
        public async Task<IActionResult> Detect(IFormFile file)
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

            bool hasPeople = new Random().Next(0, 2) == 1;

            return Ok(new
            {
                hasPeople = hasPeople
            });
        }
    }
}
