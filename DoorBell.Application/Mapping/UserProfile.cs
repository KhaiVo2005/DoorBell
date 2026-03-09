using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, DTOs.UserDTOs.GetDTO>().ReverseMap();
            CreateMap<Domain.Entities.User, DTOs.UserDTOs.CreateDTO>().ReverseMap();
            CreateMap<Domain.Entities.User, DTOs.UserDTOs.UpdateDTO>().ReverseMap();
        }
    }
}
