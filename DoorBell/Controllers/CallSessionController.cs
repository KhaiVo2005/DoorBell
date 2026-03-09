using DoorBell.Application.DTOs.CallSessionDTOs;
using DoorBell.Application.Usecases.CallSessionUsecase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoorBell.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallSessionController : ControllerBase
    {
        GetAllUsecase _getAll;
        GetUsecase _get;
        CreateUsecase _create;
        UpdateUsecase _update;
        DeleteUsecase _delete;
        AcceptUsecase _accept;
        RejectedUsecase _reject;

        public CallSessionController(
            GetAllUsecase getAll,
            GetUsecase get,
            CreateUsecase create,
            UpdateUsecase update,
            DeleteUsecase delete,
            AcceptUsecase accept,
            RejectedUsecase rejected)
        {
            _getAll = getAll;
            _get = get;
            _create = create;
            _update = update;
            _delete = delete;
            _accept = accept;
            _reject = rejected;
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
        [HttpPut("{id}/accept")]
        public async Task<IActionResult> Accept(Guid id)
        {
            var result = await _accept.Execute(id);
            return Ok(result);
        }
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> Reject(Guid id)
        {
            var result = await _reject.Execute(id);
            return Ok(result);
        }
    }
}
