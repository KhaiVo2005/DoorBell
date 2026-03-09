using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Mapping
{
    public class DoorBellEventProfile: Profile
    {
        public DoorBellEventProfile()
        {
            CreateMap<Domain.Entities.DoorBellEvent, DTOs.DoorBellEventDTOs.GetDTO>().ReverseMap();
            CreateMap<Domain.Entities.DoorBellEvent, DTOs.DoorBellEventDTOs.CreateDTO>().ReverseMap();
            CreateMap<Domain.Entities.DoorBellEvent, DTOs.DoorBellEventDTOs.UpdateDTO>().ReverseMap();
        }
    }
}
