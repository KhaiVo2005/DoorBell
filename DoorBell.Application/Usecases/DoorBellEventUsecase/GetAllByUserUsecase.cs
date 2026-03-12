using AutoMapper;
using DoorBell.Application.DTOs.DoorBellEventDTOs;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DoorBellEventUsecase
{
    public class GetAllByUserUsecase
    {
        IDoorBellEvent _doorBellEvent;
        IMapper _mapper;
    
        public GetAllByUserUsecase(IDoorBellEvent doorBellEvent, IMapper mapper)
        {
            _doorBellEvent = doorBellEvent;
            _mapper = mapper;
        }

        public async Task<List<GetDTO>> Execute(Guid userId)
        {
            var entities = await _doorBellEvent.GetByUser(userId);
            return _mapper.Map<List<GetDTO>>(entities);
        }
    }
}
