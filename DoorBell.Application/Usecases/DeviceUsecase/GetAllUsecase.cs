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
    public class GetAllUsecase
    {
        IDevice _entity;
        IMapper _mapper;

        public GetAllUsecase(IDevice entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<List<GetDTO>> Execute()
        {
            var entitys = await _entity.GetAll();
            return _mapper.Map<List<GetDTO>>(entitys);
        }
    }
}