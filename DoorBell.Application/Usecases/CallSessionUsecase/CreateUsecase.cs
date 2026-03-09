using AutoMapper;
using DoorBell.Application.DTOs.CallSessionDTOs;
using DoorBell.Application.Hubs;
using DoorBell.Application.Interfaces;
using DoorBell.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.CallSessionUsecase
{
    public class CreateUsecase
    {
        ICallSession _entity;
        IMapper _mapper;

        public CreateUsecase(ICallSession entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(CreateDTO createDTO)
        {
            var entity = _mapper.Map<CallSession>(createDTO);
            var createdEntity = await _entity.Create(entity);

            return _mapper.Map<GetDTO>(createdEntity);
        }
    }
}
