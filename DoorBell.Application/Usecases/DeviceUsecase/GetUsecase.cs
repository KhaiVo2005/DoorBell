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
    public class GetUsecase
    {
        IDevice _entity;
        IMapper _mapper;

        public GetUsecase(IDevice entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(Guid id)
        {
            var entity = await _entity.GetById(id);
            return _mapper.Map<GetDTO>(entity);
        }
    }
}
