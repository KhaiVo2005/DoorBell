using DoorBell.Application.DTOs.DeviceDTOs;
using DoorBell.Application.Usecases.DeviceUsecase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        GetAllByUserUsecase _getAllByUser;
        GetUsecase _get;
        GetAllUsecase _getAll;
        CreateUsecase _create;
        UpdateUsecase _update;
        DeleteUsecase _delete;

        public DeviceController(
            GetUsecase get, 
            GetAllByUserUsecase getAllByUser,
            GetAllUsecase getAll, 
            CreateUsecase create, 
            UpdateUsecase update, 
            DeleteUsecase delete)
        {
            _get = get;
            _getAllByUser = getAllByUser;
            _getAll = getAll;
            _create = create;
            _update = update;
            _delete = delete;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllByUser()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return BadRequest("User ID claim not found");

            var userId = Guid.Parse(userIdClaim.Value);
            var result = await _getAllByUser.Execute(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _get.Execute(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAll.Execute();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDTO request)
        {
            var result = await _create.Execute(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateDTO request)
        {
            var result = await _update.Execute(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _delete.Execute(id);
            return Ok(result);
        }
    }
}
