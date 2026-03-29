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

        public CheckCameraUseCase(IDevice deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<bool> Execute(string apiKey)
        {
            var devices = await _deviceRepository.GetByApiKey(apiKey);

            if (devices == null || devices.Count == 0)
                return false;

            var userId = devices.First().UserId;

            return await _deviceRepository.AnyRootCameraHasPeople(userId);
        }
    }
}
