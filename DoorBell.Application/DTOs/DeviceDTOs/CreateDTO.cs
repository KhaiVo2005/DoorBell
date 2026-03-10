using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.DTOs.DeviceDTOs
{
    public class CreateDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid? ParentDeviceId { get; set; }
        public string Code { get; set; }
        public string ApiKey { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Guid UserId { get; set; }
    }
}
