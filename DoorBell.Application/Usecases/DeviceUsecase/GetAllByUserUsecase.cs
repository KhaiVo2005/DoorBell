using AutoMapper;
using DoorBell.Application.DTOs.DeviceDTOs;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DeviceUsecase
{
    public class GetAllByUserUsecase
    {
        IDevice _device;
        IMapper _mapper;

        public GetAllByUserUsecase(IDevice device, IMapper mapper)
        {
            _device = device;
            _mapper = mapper;
        }

        public async Task<List<GetDTO>> Execute(Guid userId)
        {
            var entities = await _device.GetAllByUser(userId);
            return _mapper.Map<List<GetDTO>>(entities);
        }
    }
}
