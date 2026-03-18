using DoorBell.Application.Interfaces;
using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DeviceUsecase
{
    public class GetByApiKeyUsecase
    {
        private readonly IDevice _deviceRepository;
        public GetByApiKeyUsecase(IDevice deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<List<Device>> Execute(string apikey)
        {
            return await _deviceRepository.GetByApiKey(apikey);
        }
    }
}
