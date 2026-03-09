using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Domain.Entities
{
    public class DoorBellEvent
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public bool IsView { get; set; }
        public string ImageUrl { get; set; }
        // Navigation property
        public Device Device { get; set; }
    }
}
