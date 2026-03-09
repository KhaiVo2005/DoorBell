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
    public class UpdateUsecase
    {
        IDevice _entity;
        IMapper _mapper;

        public UpdateUsecase(IDevice entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(Guid id, UpdateDTO entityDTO)
        {
            var entity = await _entity.GetById(id);
            if (entity == null)
                throw new Exception("User not found");
            _mapper.Map(entityDTO, entity);
            var entityUpdate = await _entity.Update(entity);
            return _mapper.Map<GetDTO>(entityUpdate);
        }
    }
}
