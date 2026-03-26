using AutoMapper;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.CameraUsecase
{
    public class DetectUsecase
    {
        IDevice _deviceRepo;
        IMapper _mapper;

        public DetectUsecase(IDevice deviceRepo, IMapper mapper)
        {
            _deviceRepo = deviceRepo;
            _mapper = mapper;
        }

        public Task<bool> Execute(string apiKey, bool hasPeople)
        {
            var device = _deviceRepo.GetByApiKey(apiKey).Result.FirstOrDefault();
            if (device == null) return Task.FromResult(false);
            device.HasPeople = hasPeople;
            _deviceRepo.Update(device);
            return Task.FromResult(true);
        }
    }
}
