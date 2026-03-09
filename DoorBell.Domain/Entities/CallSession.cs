using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Domain.Entities
{
    public class CallSession
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        // Navigation property
        public Device Device { get; set; }
        public User User { get; set; }
    }
}
