using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Mapping
{
    public class CallSessionProfile: Profile
    {
        public CallSessionProfile()
        {
            CreateMap<Domain.Entities.CallSession, DTOs.CallSessionDTOs.GetDTO>().ReverseMap();
            CreateMap<Domain.Entities.CallSession, DTOs.CallSessionDTOs.CreateDTO>().ReverseMap();
            CreateMap<Domain.Entities.CallSession, DTOs.CallSessionDTOs.UpdateDTO>().ReverseMap();
        }
    }
}
