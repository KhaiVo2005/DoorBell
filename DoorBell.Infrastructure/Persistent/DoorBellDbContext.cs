using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Infrastructure.Persistent
{
    public class DoorBellDbContext: DbContext
    {
        public DoorBellDbContext(DbContextOptions<DoorBellDbContext> options) : base(options)
        {
        }
        public DbSet<Domain.Entities.User> Users { get; set; }
        public DbSet<Domain.Entities.Device> Devices { get; set; }
        public DbSet<Domain.Entities.DoorBellEvent> DoorBellEvents { get; set; }
        public DbSet<Domain.Entities.CallSession> CallSessions { get; set; }
    }
}
