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
    public class GetByParent
    {
        IDevice _entity;
        IMapper _mapper;

        public GetByParent(IDevice entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(string parentId)
        {
            var device = await _entity.GetByParentId(parentId);
            if (device == null)
                return null;
            return _mapper.Map<GetDTO>(device);
        }
    }
}
