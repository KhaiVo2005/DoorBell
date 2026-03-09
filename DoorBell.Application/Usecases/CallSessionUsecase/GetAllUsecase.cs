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
    public class GetAllUsecase
    {
        ICallSession _entity;
        IMapper _mapper;

        public GetAllUsecase(ICallSession entity, IMapper mapper)
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