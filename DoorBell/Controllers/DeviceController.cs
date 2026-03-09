using DoorBell.Application.DTOs.DeviceDTOs;
using DoorBell.Application.Usecases.DeviceUsecase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        GetUsecase _get;
        GetAllUsecase _getAll;
        CreateUsecase _create;
        UpdateUsecase _update;
        DeleteUsecase _delete;

        public DeviceController(GetUsecase get, GetAllUsecase getAll, CreateUsecase create, UpdateUsecase update, DeleteUsecase delete)
        {
            _get = get;
            _getAll = getAll;
            _create = create;
            _update = update;
            _delete = delete;
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
