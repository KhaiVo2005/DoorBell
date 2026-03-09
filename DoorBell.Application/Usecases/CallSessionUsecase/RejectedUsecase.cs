using AutoMapper;
using DoorBell.Application.DTOs.CallSessionDTOs;
using DoorBell.Application.Hubs;
using DoorBell.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.CallSessionUsecase
{
    public class RejectedUsecase
    {
        ICallSession _call;
        IMapper _mapper;
        IHubContext<DoorBellHub> _hub;

        public RejectedUsecase(ICallSession call, IMapper map, IHubContext<DoorBellHub> hub)
        {
            _call = call;
            _mapper = map;
            _hub = hub;
        }

        public async Task<GetDTO> Execute(Guid callSessionId)
        {
            var callSession = await _call.GetById(callSessionId);

            if (callSession == null)
                throw new Exception("Call session not found");

            callSession.Status = "Rejected";
            callSession.EndTime = DateTime.UtcNow;

            await _call.Update(callSession);

            await _hub.Clients.User(callSession.UserId.ToString())
                .SendAsync("CallRejected", new
                {
                    CallSessionId = callSession.Id
                });

            return _mapper.Map<GetDTO>(callSession);
        }
    }
}
