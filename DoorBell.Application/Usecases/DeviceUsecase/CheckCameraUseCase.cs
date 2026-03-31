using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DeviceUsecase
{
    public class CheckCameraUseCase
    {
        IDevice _deviceRepository;
        IDoorBellEvent _doorbellEvent;

        public CheckCameraUseCase(IDevice deviceRepository, IDoorBellEvent doorbellEvent)
        {
            _deviceRepository = deviceRepository;
            _doorbellEvent = doorbellEvent;
        }

        public async Task<bool> Execute(string apiKey)
        {
            var devices = await _deviceRepository.GetByApiKey(apiKey);

            if (devices == null || devices.Count == 0)
                return false;

            var userId = devices.First().UserId;

            var hasCamera = await _deviceRepository.AnyRootCameraHasPeople(userId);

            if(!hasCamera)
            {
                var createEvent = await _doorbellEvent.Create(new Domain.Entities.DoorBellEvent
                {
                    Id = Guid.NewGuid(),
                    DeviceId = devices.First().Id,
                    EventType = "isringing",
                    Timestamp = DateTime.UtcNow,
                    ImageUrl = "",
                    IsView = false
                });
            }    

            return await _deviceRepository.AnyRootCameraHasPeople(userId);
        }
    }
}
