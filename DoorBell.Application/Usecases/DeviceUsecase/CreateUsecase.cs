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
    public class CreateUsecase
    {
        IDevice _entity;
        IMapper _mapper;

        public CreateUsecase(IDevice entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(CreateDTO createDTO)
        {
            var entity = _mapper.Map<Domain.Entities.Device>(createDTO);
            var createdEntity = await _entity.Create(entity);
            return _mapper.Map<GetDTO>(createdEntity);
        }
    }
}
