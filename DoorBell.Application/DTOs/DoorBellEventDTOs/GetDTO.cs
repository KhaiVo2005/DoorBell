using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.DTOs.DoorBellEventDTOs
{
    public class GetDTO
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public bool IsView { get; set; }
        public string ImageUrl { get; set; }
        public Device Device { get; set; }
    }
}
