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
    public class GetUsecase
    {
        ICallSession _entity;
        IMapper _mapper;

        public GetUsecase(ICallSession entity, IMapper mapper)
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
