using AutoMapper;
using DoorBell.Application.DTOs.CallSessionDTOs;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.CallSessionUsecase
{
    public class UpdateUsecase
    {
        ICallSession _entity;
        IMapper _mapper;

        public UpdateUsecase(ICallSession entity, IMapper mapper)
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
