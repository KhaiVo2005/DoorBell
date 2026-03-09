using AutoMapper;
using DoorBell.Application.DTOs.DoorBellEventDTOs;
using DoorBell.Application.Hubs;
using DoorBell.Application.Interfaces;
using DoorBell.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DoorBellEventUsecase
{
    public class CreateUsecase
    {
        IDoorBellEvent _entity;
        ICallSession _call;
        IDevice _device;
        IMapper _mapper;
        IHubContext<DoorBellHub> _hub;

        public CreateUsecase(
            IDoorBellEvent entity,
            IDevice device,
            IMapper mapper, 
            ICallSession call, 
            IHubContext<DoorBellHub> hub)
        {
            _entity = entity;
            _call = call;
            _device = device;
            _mapper = mapper;
            _hub = hub;
        }

        public async Task<GetDTO> Execute(CreateDTO createDTO)
        {
            var entity = _mapper.Map<DoorBellEvent>(createDTO);
            var createdEntity = await _entity.Create(entity);

            var device = await _device.GetById(createdEntity.DeviceId);

            CallSession call = new CallSession
            {
                DeviceId = createdEntity.DeviceId,
                UserId = device.UserId, 
                StartTime = DateTime.UtcNow,
                Status = "Calling"
            };

            var createdCall = await _call.Create(call);

            await _hub.Clients.User(device.UserId.ToString())
                .SendAsync("IncomingCall", new
                {
                    CallSessionId = createdCall.Id,
                    DeviceId = device.Id,
                    Time = createdCall.StartTime
                });

            return _mapper.Map<GetDTO>(createdEntity);
        }
    }
}
