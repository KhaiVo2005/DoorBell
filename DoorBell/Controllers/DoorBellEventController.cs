using DoorBell.Application.DTOs.DoorBellEventDTOs;
using DoorBell.Application.Usecases.DoorBellEventUsecase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorBellEventController : ControllerBase
    {
        GetAllUsecase _getAll;
        GetUsecase _get;
        CreateUsecase _create;
        UpdateUsecase _update;
        DeleteUsecase _delete;

        public DoorBellEventController(GetAllUsecase getAll, GetUsecase get, CreateUsecase create, UpdateUsecase update, DeleteUsecase delete)
        {
            _getAll = getAll;
            _get = get;
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
            var result = _getAll.Execute();
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
