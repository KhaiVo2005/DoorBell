using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Mapping
{
    public class DeviceProfile: Profile
    {
        public DeviceProfile()
        {
            CreateMap<Domain.Entities.Device, DTOs.DeviceDTOs.GetDTO>().ReverseMap();
            CreateMap<Domain.Entities.Device, DTOs.DeviceDTOs.CreateDTO>().ReverseMap();
            CreateMap<Domain.Entities.Device, DTOs.DeviceDTOs.UpdateDTO>().ReverseMap();
        }
    }
}
